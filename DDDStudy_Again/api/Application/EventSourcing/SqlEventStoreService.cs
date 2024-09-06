using Domain.Core.Events;
using Infrastructure.Data.Repository.EventSourcing;
using System.Text.Json;

namespace Application.EventSourcing {
    /// <summary>
    /// 事件存储服务类
    /// </summary>
    public class SqlEventStoreService(IEventStoreRepository eventStoreRepository): IEventStoreService {
        /// <summary>
        /// 保存事务模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent"></param>
        public void Save<T>(T theEvent) where T : Event {
            //序列化事件模型
            var serialize = JsonSerializer.Serialize(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serialize,
                "eventData"
            );
            eventStoreRepository.Store(storedEvent);
        }
    }
}
