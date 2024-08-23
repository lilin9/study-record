using MongoDB.Bson;

namespace Domain.Entities {
    public class TodoList: BaseEntity {
        private TodoList() { }

        public TodoList(Builder builder) {
            Id = ObjectId.GenerateNewId().ToString();
            UserId = builder.UserId;
            Content = builder.Content;
            ExpirationTime = builder.ExpirationTime;
            IsRemind = builder.IsRemind;
            RemindTime = builder.RemindTime;
            CompleteStatus = builder.CompleteStatus;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        public string UserId { get; set; }
        public string? Content { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool IsRemind { get; set; }
        public int RemindTime { get; set; }
        public int CompleteStatus { get; set; }
    }

    public abstract partial class Builder {
        public string UserId { get; private set; }
        public string? Content { get; private set; }
        public DateTime ExpirationTime { get; private set; }
        public bool IsRemind { get; private set; }
        public int RemindTime { get; private set; }
        public int CompleteStatus { get; private set; }

        public Builder SetUserId(string userId) {
            UserId = userId;
            return this;
        }
        public Builder SetContent(string? content) {
            Content = content;
            return this;
        }
        public Builder SetExpirationTime(DateTime expirationTime) {
            ExpirationTime = expirationTime;
            return this;
        }
        public Builder SetIsRemind(bool isRemind) {
            IsRemind = isRemind;
            return this;
        }
        public Builder SetRemindTime(int remindTime) {
            RemindTime = remindTime;
            return this;
        }
        public Builder SetCompleteStatus(int completeStatus) {
            CompleteStatus = completeStatus;
            return this;
        }
    }
}
