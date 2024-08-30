using MongoDB.Bson;

namespace Domain.Entities
{
    public class TodoList : BaseEntity
    {
        public TodoList() { }

        public TodoList(Builder builder)
        {
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

        /// <summary>
        /// 待办事项关联的用户id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 待办事项内容
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpirationTime { get; set; }

        /// <summary>
        /// 是否需要提醒
        /// </summary>
        public bool IsRemind { get; set; }

        /// <summary>
        /// 提醒时间
        /// </summary>
        public DateTime RemindTime { get; set; }

        /// <summary>
        /// 这条待办事项是否已经完成
        /// </summary>
        public int CompleteStatus { get; set; }

        public class Builder
        {
            public string UserId { get; private set; }
            public string? Content { get; private set; }
            public DateTime ExpirationTime { get; private set; }
            public bool IsRemind { get; private set; }
            public DateTime RemindTime { get; private set; }
            public int CompleteStatus { get; private set; }

            public Builder SetUserId(string userId)
            {
                UserId = userId;
                return this;
            }
            public Builder SetContent(string? content)
            {
                Content = content;
                return this;
            }
            public Builder SetExpirationTime(DateTime expirationTime)
            {
                ExpirationTime = expirationTime;
                return this;
            }
            public Builder SetIsRemind(bool isRemind)
            {
                IsRemind = isRemind;
                return this;
            }
            public Builder SetRemindTime(DateTime remindTime)
            {
                RemindTime = remindTime;
                return this;
            }
            public Builder SetCompleteStatus(int completeStatus)
            {
                CompleteStatus = completeStatus;
                return this;
            }
        }
    }
}
