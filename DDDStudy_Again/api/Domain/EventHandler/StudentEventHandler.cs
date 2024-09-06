using Domain.Core.Events.Student;
using MediatR;

namespace Domain.EventHandler {
    /// <summary>
    /// Student 事件处理程序，继承 INotificationHandler<T>，
    /// 可以同时处理多个不同的事件模型
    /// </summary>
    public class StudentEventHandler:
        INotificationHandler<StudentRegisteredEvent>,
        INotificationHandler<StudentUpdatedEvent>,
        INotificationHandler<StudentRemovedEvent> {
       
        //学生被注册后的事件处理方法
        public Task Handle(StudentRegisteredEvent notification, CancellationToken cancellationToken) {
            //TODO 添加后的操作
            return Task.CompletedTask;
        }

        //学生被修改成功后的事件处理方法
        public Task Handle(StudentUpdatedEvent notification, CancellationToken cancellationToken) {
            //TODO 修改后的操作
            return Task.CompletedTask;
        }

        //学生被删除后的事件处理方法
        public Task Handle(StudentRemovedEvent notification, CancellationToken cancellationToken) {
            //TODO 删除后的操作
            return Task.CompletedTask;
        }
    }
}
