using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository.Entities {
    public class BaseEntity {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; }

        public DateTime CreateTime { get; init; }

        public DateTime? UpdateTime { get; protected set; }
    }
}
