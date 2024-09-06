using Domain.Interfaces;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.UnityOfWorks {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnityOfWork(StudentContext studentContext): IUnityOfWork {
        /// <summary>
        /// 提交上下文
        /// </summary>
        /// <returns></returns>
        public bool Commit() {
            return studentContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose() {
            studentContext.Dispose();
        }
    }
}
