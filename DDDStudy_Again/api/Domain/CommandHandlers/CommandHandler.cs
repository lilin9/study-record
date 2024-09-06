using Domain.Core.Bus;
using Domain.Core.Commands;
using Domain.Core.Notifications;
using Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.CommandHandlers {
    /// <summary>
    /// 领域命令处理程序
    /// 作为全部处理程序的基类，提供公共方法和接口数据
    /// </summary>
    public class CommandHandler(
        //工作单元
        IUnityOfWork uow,
        //注入中介处理接口
        IMediatorHandler bus,
        //注入缓存
        IMemoryCache cache) {

        public bool Commit() {
            if (uow.Commit()) {
                return true;
            }

            //TODO 如果异常，进行领域通知
            return false;
        }

        /// <summary>
        /// 将领域命令中的验证错误信息收集
        /// </summary>
        /// <param name="command"></param>
        protected void NotifyValidationErrors(Command command) {
            // var errorInfos = command.ValidationResult.Errors
            //     .Select(err => err.ErrorMessage).ToList();
            // //注入缓存
            // cache.Set("ErrorData", errorInfos);

            //通过事件总线将错误信息派发出去
            command.ValidationResult.Errors.ForEach(err => {
                bus.RaiseEvent(new DomainNotification("", err.ErrorMessage));
            });
        }
    }
}
