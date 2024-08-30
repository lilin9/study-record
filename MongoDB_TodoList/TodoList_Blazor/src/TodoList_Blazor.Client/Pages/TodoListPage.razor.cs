using AntDesign.TableModels;
using Application.Services;
using Application.ViewObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using TodoList_Blazor.Client.Common;

namespace TodoList_Blazor.Client.Pages
{
    public partial class TodoListPage
    {
        //表格索引
        private ITable _tableRef = null!;
        //待办事项列表
        private List<TodoList>? TodoLists { get; set; }
        //待办事项表格数据源
        private List<TodoList> TodoDataSource { get; set; } = null!;
        //数据总数量
        private int _totalCount = 0;
        //修改框显隐控制
        private bool EditVisible { get; set; }
        //要修改的Todo数据
        private TodoList? EditTodoData { get; set; }
        //表格的选中行
        private IEnumerable<TodoList> SelectedRows { get; set; } = null!;

        [Inject]
        [NotNull]
        private TodoListService TodoService { get; set; }

        [Inject]
        private IMessageService MessageService { get; set; } = null!;

        /// <summary>
        /// 表格发生改变事件
        /// </summary>
        /// <param name="query"></param>
        void OnChangeHandler(QueryModel<TodoList> query)
        {
            if (TodoLists == null)
            {
                return;
            }

            var tableQuery = TodoLists.AsQueryable().ExecuteTableQuery(query);
            _totalCount = tableQuery.Count();
            TodoDataSource = tableQuery.CurrentPagedRecords(query).ToList();
        }

        /// <summary>
        /// 修改按钮点击事件
        /// </summary>
        /// <param name="row"></param>
        async void OnEditHandler(TodoList row)
        {
            EditVisible = true;
            EditTodoData = ObjectUtil.DeepCopy(row);
        }

        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="row"></param>
        async Task OnDeleteHandler(TodoList row)
        {
            if (string.IsNullOrEmpty(row.Id))
            {
                await MessageService.Error("请重新选择数据");
                return;
            }

            var isExists = await ExistsById(row.Id);
            if (!isExists)
            {
                await MessageService.Error("选择的数据不存在，请刷新后重试");
                return;
            }

            var deleteResult = await TodoService.Delete(row.Id);
            if (deleteResult)
            {
                await MessageService.Success("删除成功");
                _tableRef.ReloadData();
            }
            else
            {
                await MessageService.Error("删除失败");
            }
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            await GetAllTodoList();
            _tableRef.ReloadData();
        }

        /// <summary>
        /// 待办事项修改弹出框，点击按钮点击会触发的事件
        /// </summary>
        /// <param name="editedModel"></param>
        private async Task TodoListEditHandler(TodoList editedModel)
        {
            var todoVm = ObjectUtil.ObjectCopy<TodoList, TodoVm>(editedModel);
            // var todoVm = new TodoVm
            // {
            //     CompleteStatus = editedModel.CompleteStatus,
            //     Content = editedModel.Content,
            //     ExpirationTime = editedModel.ExpirationTime,
            //     IsRemind = editedModel.IsRemind,
            //     RemindTime = editedModel.RemindTime,
            //     UserId = editedModel.UserId
            // };
            _ = await TodoService.UpdateTodoList(editedModel.Id, todoVm);
            await MessageService.Success("编辑成功！");
            _tableRef.ReloadData();
            EditVisible = false;
        }

        /// <summary>
        /// 获取所有待办事项数据
        /// </summary>
        /// <returns></returns>
        private async Task GetAllTodoList()
        {
            var todos = await TodoService.GetAllTodoList();
            TodoLists = todos.ToList();
        }

        /// <summary>
        /// 传入Id判断TodoList是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<bool> ExistsById(string id)
        {
            var result = await TodoService.GetTodoListById(id);
            return result != null;
        }
    }
}
