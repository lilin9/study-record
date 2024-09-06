using Domain.Core.Events;

namespace Domain.Core.Notifications {
    /// <summary>
    /// 领域通知模型，用来获取当前总线中出现的通知信息
    /// 继承自领域事件和 INotification （也就意味着可以拥有中介的发布/订阅模式）
    /// </summary>
    public class DomainNotification(string key, string value): Event {
        /// <summary>
        /// 标识
        /// </summary>
        public Guid DomainNotificationId { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// 键
        /// 通过key，可以获取当前key下所有通知信息
        /// </summary>
        public string Key { get; private set; } = key;

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; private set; } = value;

        /// <summary>
        /// 版本信息
        /// </summary>
        public int Version { get; private set; } = 1;
    }
}
