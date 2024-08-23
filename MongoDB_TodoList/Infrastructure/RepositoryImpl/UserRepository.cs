using Domain;
using Domain.Entities;
using Domain.Repository;

namespace Infrastructure.RepositoryImpl {
    public class UserRepository(IMongoDbContext context) : MongoDbRepository<UserInfo>(context), IUserRepository;
}
