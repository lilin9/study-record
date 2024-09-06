using MediatR;

namespace Domain.Core.Events {
    /// <summary>
    /// 抽象类 Message，用来获取事件执行过程中的类名
    /// </summary>
    public abstract class Message: IRequest {
        public string MessageType { get; protected set; }
        public Guid AggregatedId { get; protected set; }

        protected Message() {
            MessageType = GetType().Name;
        }
    }
}
