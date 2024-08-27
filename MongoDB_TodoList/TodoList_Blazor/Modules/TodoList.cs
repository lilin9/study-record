using System.ComponentModel;

namespace TodoList_Blazor.Modules {
    public record TodoList {
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        public string Id { get; set; }
        /// <summary>
        /// 待办事项关联的用户id
        /// </summary>
        [DisplayName("用户Id")]
        public string UserId { get; set; }

        /// <summary>
        /// 待办事项内容
        /// </summary>
        [DisplayName("内容")]
        public string? Content { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [DisplayName("过期时间")]
        public DateTime ExpirationTime { get; set; }

        /// <summary>
        /// 是否需要提醒
        /// </summary>
        [DisplayName("是否提醒")]
        public bool IsRemind { get; set; }

        /// <summary>
        /// 提醒时间
        /// </summary>
        [DisplayName("提醒时间")]
        public int RemindTime { get; set; }

        /// <summary>
        /// 这条待办事项是否已经完成
        /// </summary>
        [DisplayName("是否完成")]
        public int CompleteStatus { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DisplayName("修改时间")]
        public DateTime? UpdateTime { get; set; }
    }
}