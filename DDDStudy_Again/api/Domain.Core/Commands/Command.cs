
using MediatR;

namespace Domain.Core.Commands {
    /// <summary>
    /// 创建领域命令基类
    /// </summary>
    public abstract class Command: IRequest {
        //时间戳
        public DateTime Timestamp { get; private set; }
        //验证结果：需要引入FluentValidation
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }

        protected Command() {
            Timestamp = DateTime.Now;
        }

        //定义抽象方法，是否有效
        public abstract bool IsValid();
    }
}
