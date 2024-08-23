using Domain.Entities;

namespace Domain.Repository {
    public interface IUserRepository: IMongoDbRepository<UserInfo> {
    }
}
