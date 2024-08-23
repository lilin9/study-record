using MongoDB.Driver;

namespace Domain {
    public interface IMongoDbContext: IDisposable {
        /// <summary>
        /// 添加命令
        /// </summary>
        /// <param name="func">委托参数，接受一个 Func<IClientSessionHandle, Task> 类型的委托作为参数，
        /// 该委托表示需要一个IClientSessionHandler对象作为参数并返回一个异步任务的方法</param>
        /// <returns></returns>
        Task AddCommandAsync(Func<IClientSessionHandle, Task> func);

        /// <summary>
        /// 提交更改，并返回受影响的行数（单机不支持事务操作，集群支持）
        /// </summary>
        /// <param name="session">MongoDb会话对象</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(IClientSessionHandle session);

        /// <summary>
        /// 初始化MongoDb会话对象（session）
        /// </summary>
        /// <returns></returns>
        Task<IClientSessionHandle> StartSessionAsync();

        /// <summary>
        /// 获取集合数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
