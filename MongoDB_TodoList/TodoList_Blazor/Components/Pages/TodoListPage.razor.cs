using System.ComponentModel.DataAnnotations;
using Application.Services;
using Microsoft.AspNetCore.Components;

namespace TodoList_Blazor.Components.Pages {
    public partial class TodoListPage {
        [Inject]
        [Required]
        private TodoListService TodoListService { get; set; } = null!;

        private List<Modules.TodoList>? TodoLists { get; set; }

        protected override async Task OnInitializedAsync() {
            //初始化 TodoLists
            await InitTodoLists();
        }

        /// <summary>
        /// 对 TodoLists 列表进行初始化
        /// </summary>
        /// <returns></returns>
        private async Task InitTodoLists() {
            var todoLists = await TodoListService.GetAllTodoList();
            TodoLists = todoLists.Select(t => new Modules.TodoList {
                Id = t.Id,
                UserId = t.UserId,
                CompleteStatus = t.CompleteStatus,
                Content = t.Content,
                CreateTime = t.CreateTime,
                ExpirationTime = t.ExpirationTime,
                IsRemind = t.IsRemind,
                RemindTime = t.RemindTime,
                UpdateTime = t.UpdateTime
            }).ToList();
        }
    }
}