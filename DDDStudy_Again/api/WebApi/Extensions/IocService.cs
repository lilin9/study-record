using Application.EventSourcing;
using Application.Interfaces;
using Application.Service;
using Domain.CommandHandlers;
using Domain.Core.Bus;
using Domain.Core.Commands.Student;
using Domain.Core.Events;
using Domain.Core.Events.Student;
using Domain.Core.Notifications;
using Domain.EventHandler;
using Domain.Interfaces;
using Infrastructure.Data.Bus;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repository;
using Infrastructure.Data.UnityOfWorks;
using MediatR;

namespace WebApi.Extensions {
    public static class IocService {
        /// <summary>
        /// 注册所有依赖注入服务
        /// </summary>
        /// <param name="services"></param>
        public static void RegistryServices(this IServiceCollection services) {
            services.AddScoped<IStudentAppService, StudentAppService>();
            services.AddScoped<IEventStoreService, SqlEventStoreService>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudentContext>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, Unit>, StudentCommandHandler>();

            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentUpdatedEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentRemovedEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}
