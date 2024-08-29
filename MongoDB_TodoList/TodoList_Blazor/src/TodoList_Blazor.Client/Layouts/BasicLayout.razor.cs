using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;

namespace TodoList_Blazor.Client.Layouts
{
    public partial class BasicLayout
        : LayoutComponentBase, IDisposable
    {
        [Inject]
        private ReuseTabsService TabService { get; set; }

        private MenuDataItem[] MenuData { get; set; }

        private static bool _collapsed;

        public BasicLayout() { }

        public BasicLayout(MenuDataItem[] menuData, bool collapsed, ReuseTabsService tabService)
        {
            MenuData = menuData;
            _collapsed = collapsed;
            TabService = tabService;
        }

        protected override Task OnInitializedAsync()
        {
            MenuData = new[] {
                new MenuDataItem {
                    Path = "/",
                    Name = "Welcome",
                    Key = "welcome",
                    Icon = "smile",
                },
                new MenuDataItem
                {
                    Path = "/todoList",
                    Name = "待办清单",
                    Key = "TodoList",
                    Icon = "unordered-list"
                },
                new MenuDataItem
                {
                    Path = "/personal",
                    Name = "个人信息",
                    Key = "Personal",
                    Icon = "user"
                },
                new MenuDataItem
                {
                    Path = "/system",
                    Name = "系统更新",
                    Key = "System",
                    Icon = "setting"
                }
            };
            return Task.CompletedTask;
        }

        void Reload()
        {
            TabService.ReloadPage();
        }

        public void Dispose()
        {

        }

    }
}
