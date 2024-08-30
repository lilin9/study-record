using Application.ViewObjects;
using Domain.Entities;
using Domain.Repository;
using Infrastructure;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Application.Services
{
    public class TodoListService(UnityOfWork unityOfWork, ITodoListRepository todoListRepository)
    {
        /// <summary>
        /// 查找所有待办事项列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TodoList>> GetAllTodoList()
        {
            return await todoListRepository.GetAllAsync();
        }

        /// <summary>
        /// 分页查询待办事项列表
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TodoList>> GetTodoListByPage(TodoPageVm vm)
        {
            //构造查询条件
            var builderFilter = Builders<TodoList>.Filter;
            var filter = builderFilter.Empty;
            //根据创建时间进行排序
            var sort = Builders<TodoList>.Sort.Ascending(t => t.CreateTime);

            //根据待办事项内容进行查询
            if (!string.IsNullOrEmpty(vm.Content))
            {
                filter = builderFilter.Eq(t => t.Content, vm.Content);
            }
            //根据 Id 查询
            if (!string.IsNullOrEmpty(vm.Id))
            {
                filter = builderFilter.Eq(t => t.Id, vm.Id);
            }

            return await todoListRepository.FindListByPageAsync(
                filter,
                vm.PageIndex,
                vm.PageSize,
                [],
                sort
            );
        }

        /// <summary>
        /// 根据id查询待办事项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TodoList?> GetTodoListById(string id)
        {
            return await todoListRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 添加一条待办事项
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        public async Task<TodoList> AddTodoList(TodoVm todo)
        {
            var todoBuild = new TodoList.Builder()
                .SetContent(todo.Content)
                .SetCompleteStatus(todo.CompleteStatus)
                .SetExpirationTime(todo.ExpirationTime)
                .SetIsRemind(todo.IsRemind)
                .SetUserId(todo.UserId)
                .SetRemindTime(todo.RemindTime);
            var todoList = new TodoList(todoBuild);

            await todoListRepository.AddAsync(todoList);
            return await todoListRepository.GetByIdAsync(todoList.Id);
        }

        /// <summary>
        /// 通过事务来添加待办事项
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        public async Task<TodoList> AddTransactionTodoList(TodoVm todo)
        {
            using var session = await unityOfWork.InitTransaction();

            var todoBuild = new TodoList.Builder()
                .SetContent(todo.Content)
                .SetCompleteStatus(todo.CompleteStatus)
                .SetExpirationTime(todo.ExpirationTime)
                .SetIsRemind(todo.IsRemind)
                .SetUserId(todo.UserId)
                .SetRemindTime(todo.RemindTime);
            var todoList = new TodoList(todoBuild);

            //进行事务性添加
            await todoListRepository.AddTransactionsAsync(session, todoList);
            //提交事务
            await unityOfWork.Commit(session);

            return await todoListRepository.GetByIdAsync(todoList.Id);
        }

        /// <summary>
        /// 传入id，根据id修改待办事项
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todo"></param>
        /// <returns></returns>
        public async Task<TodoList> UpdateTodoList(string id, TodoVm todo)
        {
            //创建修改条件
            var list = new List<FilterDefinition<TodoList>> {
                Builders<TodoList>.Filter.Eq("_id", new ObjectId(id))
            };
            var filter = Builders<TodoList>.Filter.And(list);

            //指定需要修改的字段
            var updateDefinition = Builders<TodoList>.Update
                .Set(t => t.Content, todo.Content)
                .Set(t => t.ExpirationTime, todo.ExpirationTime)
                .Set(t => t.CompleteStatus, todo.CompleteStatus)
                .Set(t => t.RemindTime, todo.RemindTime)
                .Set(t => t.IsRemind, todo.IsRemind)
                .Set(t => t.UpdateTime, DateTime.Now);

            //修改数据
            await todoListRepository.UpdateAsync(filter, updateDefinition);
            return await todoListRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据id删除指定待办事项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            await todoListRepository.DeleteAsync(id);
            var todoList = (TodoList?)await todoListRepository.GetByIdAsync(id);
            return todoList == null;
        }
    }
}
