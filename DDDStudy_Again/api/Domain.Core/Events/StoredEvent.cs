namespace Domain.Core.Events {
    public class StoredEvent: Event {
        /// <summary>
        /// 构造方法实例化
        /// </summary>
        public StoredEvent(Event theEvent, string data, string user) {
            Id = Guid.NewGuid();
            AggregatedId = theEvent.AggregatedId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
        }

        protected StoredEvent() { }

        /// <summary>
        /// 事件存储 Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// 需要存储的数据
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public string User { get; private set; }
    }
}
