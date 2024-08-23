using Domain;
using MongoDB.Driver;
using static System.GC;

namespace Infrastructure {
    public class MongoDbContext(IMongoConnection connection): IMongoDbContext {
        private readonly IMongoDatabase _databaseName = connection.DatabaseName;
        private readonly MongoClient _mongoClient = connection.MongoDbClient;

        //这里将 _commands 的每个元素都定义为 Func<IClientSessionHandle, Task> 委托，
        //此委托表示需要一个 IClientSessionHandle 对象作为参数并且返回一个异步任务的方法。
        //每个委托都表示一个MongoDb会话对象和要执行的命令。
        private readonly List<Func<IClientSessionHandle, Task>> _commands = [];

        /// <summary>
        /// 添加命令
        /// </summary>
        /// <param name="func">委托参数，接受一个 Func<IClientSessionHandle, Task> 类型的委托作为参数，
        /// 该委托表示需要一个IClientSessionHandler对象作为参数并返回一个异步任务的方法</param>
        /// <returns></returns>
        public async Task AddCommandAsync(Func<IClientSessionHandle, Task> func) {
            _commands.Add(func);
            await Task.CompletedTask;
        }

        /// <summary>
        /// 提交更改，将数据写入MongoDB，并返回受影响的行数（单机不支持事务操作，集群支持）
        /// </summary>
        /// <param name="session">MongoDb会话对象</param>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync(IClientSessionHandle session) {
            try {
                //开启事务操作
                session.StartTransaction();

                //command实现了对事务中所有操作的异步执行。如果无异常，程序继续向下执行，
                //并且将之前所进行的所有更改一并提交到MongoDb服务器上，实现事务提交
                _commands.ForEach(async command => {
                    await command(session);
                });

                //提交事务
                await session.CommitTransactionAsync();
                return _commands.Count;
            } catch (Exception e) {
                //事务回滚
                await session.AbortTransactionAsync();
                return 0;
            }
        }

        /// <summary>
        /// 初始化MongoDb会话对象（session）
        /// </summary>
        /// <returns></returns>
        public async Task<IClientSessionHandle> StartSessionAsync() {
            return await _mongoClient.StartSessionAsync();
        }

        /// <summary>
        /// 获取Mongo集合数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">集合名</param>
        /// <returns></returns>
        public IMongoCollection<T> GetCollection<T>(string name) {
            return _databaseName.GetCollection<T>(name);
        }


        /// <summary>
        /// 释放上下文
        /// </summary>
        public void Dispose() {
            SuppressFinalize(this);
        }
    }
}
