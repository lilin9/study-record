using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using UserMgr.Domain;
using UserMgr.Domain.Entities;
using UserMgr.Domain.ValueObject;

namespace UserMgr.Infrastructure;

public class UserRepository(MySqlDbContext dbContext, 
    IDistributedCache distributedCache,
    IMediator mediator): IUserRepository {
    public Task<User?> FindOneAsync(PhoneNumber phoneNumber) {
        var user = dbContext.Users.Include(u => u.UserAccessFail)
            .SingleOrDefault(u => u.PhoneNumber.Number.Equals(phoneNumber.Number));
        return Task.FromResult(user);
    }

    public Task<User?> FindOneAsync(Guid userId) {
        var user = dbContext.Users.Include(u=>u.UserAccessFail)
            .SingleOrDefault(u => u.Id == userId);
        return Task.FromResult(user);
    }

    public async Task AddNewLoginHistory(PhoneNumber phoneNumber, string message) {
        var user = await FindOneAsync(phoneNumber);
        Guid? userId = null;
        if (user != null) {
            userId = user.Id;
        }

        dbContext.UserLoginHistories.Add(new UserLoginHistory(userId, phoneNumber, message));
    }

    public Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code) {
        var key = $"PhoneNumberCode_{phoneNumber.RegionNumber}_{phoneNumber.Number}";
        return distributedCache.SetStringAsync(key, code, new DistributedCacheEntryOptions {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        });
    }

    public async Task<string?> FindPhoneNumberCodeAsync(PhoneNumber phoneNumber) {
        var key = $"PhoneNumberCode_{phoneNumber.RegionNumber}_{phoneNumber.Number}";
        var code = await distributedCache.GetStringAsync(key);
        distributedCache.Remove(key);
        return code;
    }

    public Task PublishEventAsync(UserAccessResultEvent resultEvent) {
        return mediator.Publish(resultEvent);
    }
}