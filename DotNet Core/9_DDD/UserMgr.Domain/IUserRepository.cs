using UserMgr.Domain.Entities;
using UserMgr.Domain.ValueObject;

namespace UserMgr.Domain;

public interface IUserRepository {
    public Task<User?> FindOneAsync(PhoneNumber phoneNumber);
    public Task<User?> FindOneAsync(Guid userId);
    public Task AddNewLoginHistory(PhoneNumber phoneNumber, string message);
    public Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code);
    public Task<string?> FindPhoneNumberCodeAsync(PhoneNumber phoneNumber);
    public Task PublishEventAsync(UserAccessResultEvent resultEvent);
}