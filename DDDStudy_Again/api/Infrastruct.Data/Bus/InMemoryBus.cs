using Domain.Core.Bus;
using Domain.Core.Commands;
using Domain.Core.Events;
using MediatR;

namespace Infrastructure.Data.Bus {
    /// <summary>
    /// 一个密封类，实现中介记忆总线
    /// </summary>
    public class InMemoryBus(IMediator mediator, IEventStoreService eventStoreService): IMediatorHandler {
        public async Task SenderCommandAsync<T>(T command) where T : Command {
            await mediator.Send(command);
        }

        /// <summary>
        /// 引发事件
        /// 通过总线发布事件
        ///
        /// 这个方法和Command不一样，一个是RegisterStudentCommand注册学生命令之前，
        /// 一个是StudentRegisteredEvent学生被注册事件之后
        /// </summary>
        /// <typeparam name="T">泛型，继承 Event:INotification</typeparam>
        /// <param name="event">事件模型，比如 StudentRegisteredEvent</param>
        /// <returns></returns>
        public Task RaiseEvent<T>(T @event) where T : Event {
            //对引发的事件进行持久化
            if (!@event.MessageType.Equals("DomainNotification")) {
                eventStoreService?.Save(@event);
            }

            return mediator.Publish(@event);
        }
    }
}
