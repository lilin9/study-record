using Application.Services;
using Domain;
using Domain.Repository;
using Infrastructure;
using Infrastructure.RepositoryImpl;

namespace TodoList_Blazor.Client.Extensions
{
    public static class IocExtensions
    {
        /// <summary>
        /// ioc注入统一管理
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IMongoConnection, MongoConnection>();
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITodoListRepository, TodoListRepository>();

            services.AddScoped<UnityOfWork>();
            services.AddScoped<UserServices>();
            services.AddScoped<TodoListService>();
        }
    }
}
