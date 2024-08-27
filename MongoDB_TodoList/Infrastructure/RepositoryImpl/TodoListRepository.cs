using Domain;
using Domain.Entities;
using Domain.Repository;

namespace Infrastructure.RepositoryImpl {
    public class TodoListRepository(IMongoDbContext context) : MongoDbRepository<TodoList>(context), ITodoListRepository;
}
