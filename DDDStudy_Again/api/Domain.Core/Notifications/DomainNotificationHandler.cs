using MediatR;

namespace Domain.Core.Notifications {
    /// <summary>
    /// 领域通知处理程序，把所有的通知信息都放到事件总线中
    /// 继承 INotificationHandler<DomainNotification>
    /// </summary>
    public class DomainNotificationHandler: INotificationHandler<DomainNotification> {
        //信息通知列表
        private List<DomainNotification> _notifications = new();

        /// <summary>
        /// 将通知信息都添加到 _notifications 内
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(DomainNotification notification, CancellationToken cancellationToken) {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取当前生命周期内的全部通知信息
        /// </summary>
        /// <returns></returns>
        public virtual List<DomainNotification> GetNotifications() {
            return _notifications;
        }

        /// <summary>
        /// 判断在当前总线对象周期中，是否存在通知信息。
        /// </summary>
        /// <returns></returns>
        public virtual bool HasNotifications() {
            return GetNotifications().Any();
        }

        /// <summary>
        /// 手动对通知信息列表进行回收
        /// </summary>
        public void Dispose() {
            _notifications = [];
        }
    }
}
