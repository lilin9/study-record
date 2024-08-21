namespace Repository.Entities {
    public class TodoList: BaseEntity {
        private TodoList() { }

        public TodoList(string userId, string? content, DateTime expirationTime, bool isRemind, int remindTime,
            byte completeStatus) {
            UserId = userId;
            Content = content;
            ExpirationTime = expirationTime;
            IsRemind = isRemind;
            RemindTime = remindTime;
            CompleteStatus = completeStatus;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        public string UserId { get; private set; }
        public string? Content { get; private set; }
        public DateTime ExpirationTime { get; private set; }
        public bool IsRemind { get; private set; }
        public int RemindTime { get; private set; }
        public byte CompleteStatus { get; private set; }
    }
}
