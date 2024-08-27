using Domain.Entities;

namespace Domain.Repository {
    public interface ITodoListRepository: IMongoDbRepository<TodoList> {
    }
}
