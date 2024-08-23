using MongoDB.Driver;

namespace Domain
{
    public interface IMongoConnection
    {
        public MongoClient MongoDbClient { get; set; }
        public IMongoDatabase DatabaseName { get; set; }
    }
}
