using AntDesign;
using AntDesign.TableModels;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Components;

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
        private TodoList EditTodoData { get; set; }

        [Inject]
        private TodoListService TodoService { get; set; } = null!;

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
            EditTodoData = row;
        }

        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="row"></param>
        async void OnDeleteHandler(TodoList row)
        {
            await MessageService.Error("bad boy");
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
        /// 待办事项修改函数
        /// </summary>
        /// <param name="editedModel"></param>
        private void TodoListEditHandler(TodoList editedModel)
        {

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
    }
}
