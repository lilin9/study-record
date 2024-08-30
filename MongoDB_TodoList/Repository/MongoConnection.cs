using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Domain
{
    /// <summary>
    /// 基于MongoDB的最佳实践是将MongoClient设置为单例注入模式，因为在MongoDb.Driver中MongoClient已经被设计为线程安全，
    /// 这样可以避免反复实例化MongoClient带来的开销，避免在极端情况下的性能低效。
    /// 这里涉及一个MongoConnection类，用于包裹MongoDbClient，然后将其以单例模式注入IOC容器中。
    /// </summary>
    public class MongoConnection : IMongoConnection
    {
        public MongoClient MongoDbClient { get; set; }

        public IMongoDatabase DatabaseName { get; set; }

        public MongoConnection(IConfiguration configuration)
        {
            MongoDbClient = new MongoClient(configuration["MongoSettings:MongoDbConnStr"]!);
            DatabaseName = MongoDbClient.GetDatabase(configuration["MongoSettings:MongoDbName"]!);
        }

    }
}
