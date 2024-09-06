using MediatR;

namespace Domain.Core.Events {
    /// <summary>
    /// 事件模型基类，继承 INotification
    /// 此接口拥有中介者模式中的 发布/订阅模式
    /// </summary>
    public abstract class Event: INotification {
        protected Event() {
            MessageType = GetType().Name;
        }
        public DateTime Timestamp { get; private set; } = DateTime.Now;
        public string MessageType { get; protected set; }
        public Guid AggregatedId { get; protected set; }
    }
}
