using Domain.Core.Events;

namespace Infrastructure.Data.Repository.EventSourcing {
    /// <summary>
    /// 事件存储仓储接口
    /// </summary>
    public interface IEventStoreRepository: IDisposable {
        void Store(StoredEvent theEvent);

        IList<StoredEvent> All(Guid aggregateId);
    }
}
