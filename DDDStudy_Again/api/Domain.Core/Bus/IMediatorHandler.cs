using Domain.Core.Commands;
using Domain.Core.Events;

namespace Domain.Core.Bus {
    /// <summary>
    /// 中介处理程序接口
    /// 可以定义多个处理程序
    /// </summary>
    public interface IMediatorHandler {
        /// <summary>
        /// 发布命令，将命令模型发布到中介者模块
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="command">命令模型</param>
        /// <returns></returns>
        Task SenderCommandAsync<T>(T command) where T : Command;

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
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
