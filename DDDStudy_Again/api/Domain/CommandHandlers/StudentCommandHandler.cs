using Domain.Core.Bus;
using Domain.Core.Commands.Student;
using Domain.Core.Events.Student;
using Domain.Core.Notifications;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Domain.CommandHandlers {
    public class StudentCommandHandler(ILogger logger, IStudentRepository studentRepository, IUnityOfWork uow, IMediatorHandler bus, IMemoryCache cache):
        CommandHandler(uow, bus, cache),
        IRequestHandler<RegisterStudentCommand, Unit>,
        IRequestHandler<UpdateStudentCommand, Unit>,
        IRequestHandler<RemoveStudentCommand, Unit> {
        /// <summary>
        /// RegisterStudentCommand 命令的处理程序
        /// 整个命令处理程序的核心都在这
        /// 不仅包括命令验证的收集、持久化，还有领域事件和通知的添加
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Unit> Handle(RegisterStudentCommand request, CancellationToken cancellationToken) {
            //命令验证
            if (!request.IsValid()) {
                //收集错误信息
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }

            //实例化领域模型
            var customer = new Student(Guid.NewGuid(), request.Name, request.Email, request.BirthDate, request.Phone);
            //验证邮箱是否存在
            //这些业务逻辑，当然要在领域层（领域命令处理程序）中处理
            if (studentRepository.GetByEmail(customer.Email) != null) {
                //处理错误信息：发布到缓存内
                // cache.Set("ErrorData", new List<string>() {
                //     "The customer e-mail has already been taken"
                // });

                //处理错误信息：引发错误事件
                bus.RaiseEvent(new DomainNotification("", "该邮箱已被使用"));

                return Task.FromResult(new Unit());
            }

            //持久化到数据库
            studentRepository.Add(customer);

            //统一提交
            if (Commit()) {
                //提交成功后的后续操作：发邮件/发短信
                bus.RaiseEvent(new StudentRegisteredEvent(
                    customer.Id, customer.Name, customer.Email, request.BirthDate, customer.Phone
                ));
            }
            return Task.FromResult(new Unit());
        }

        /// <summary>
        /// UpdateStudentCommand 处理方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// RemoveStudentCommand 处理方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
