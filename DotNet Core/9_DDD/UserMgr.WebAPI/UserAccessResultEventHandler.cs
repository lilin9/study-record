using MediatR;
using UserMgr.Domain;
using UserMgr.Infrastructure;

namespace UserMgr.WebAPI;

public class UserAccessResultEventHandler(IServiceScopeFactory serviceScopeFactory): INotificationHandler<UserAccessResultEvent> {
    public async Task Handle(UserAccessResultEvent notification, CancellationToken cancellationToken) {
        using var scope = serviceScopeFactory.CreateScope();
        IUserRepository userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
        var dbContext = scope.ServiceProvider.GetRequiredService<MySqlDbContext>();
        
        await userRepository.AddNewLoginHistory(notification.PhoneNumber,
            $"登录结果是：{notification.UserAccessResult}");
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}






