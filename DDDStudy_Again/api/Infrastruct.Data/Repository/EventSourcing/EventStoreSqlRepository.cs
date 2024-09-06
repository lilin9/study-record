using Domain.Core.Events;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.Repository.EventSourcing {
    public class EventStoreSqlRepository(EventStoreSqlContext context): IEventStoreRepository {
        public void Dispose() {
            context.Dispose();
        }

        /// <summary>
        /// 持久化命令事件
        /// </summary>
        /// <param name="theEvent"></param>
        public void Store(StoredEvent theEvent) {
            context.StoredEvents.Add(theEvent);
            context.SaveChanges();
        }

        /// <summary>
        /// 根据聚合根 id 获取全部的事件
        /// 聚合指领域模型的聚合根模型
        /// </summary>
        /// <param name="aggregateId">聚合根id，如：订单模型Id</param>
        /// <returns></returns>
        public IList<StoredEvent> All(Guid aggregateId) {
            return context.StoredEvents
                .Where(e => e.AggregatedId == aggregateId)
                .ToList();
        }
    }
}
