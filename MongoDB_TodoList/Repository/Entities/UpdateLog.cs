using MongoDB.Bson;

namespace Domain.Entities
{
    public class UpdateLog : BaseEntity
    {
        private UpdateLog() { }

        public UpdateLog(Builder builder)
        {
            Id = ObjectId.GenerateNewId().ToString();
            UpdateContent = builder.UpdateLog;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        public string? UpdateContent { get; set; }
    }

    public abstract partial class Builder
    {
        public string? UpdateLog { get; private set; }

        public Builder SetUpdateLog(string? updateLog)
        {
            UpdateLog = updateLog;
            return this;
        }
    }
}
