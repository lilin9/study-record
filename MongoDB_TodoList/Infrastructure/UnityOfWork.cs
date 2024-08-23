using Domain;
using MongoDB.Driver;

namespace Infrastructure {
    /// <summary>
    /// 在工作单元里统一管理所有Repository的SaveChanges和事物的回滚与提交
    /// </summary>
    public class UnityOfWork(IMongoDbContext dbContext): IDisposable {
        public void Dispose() {
            dbContext.Dispose();
        }

        /// <summary>
        /// 提交保存
        /// </summary>
        /// <param name="session">MongoDb会话</param>
        /// <returns></returns>
        public async Task<bool> Commit(IClientSessionHandle session) {
            return await dbContext.SaveChangesAsync(session) > 0;
        }

        /// <summary>
        /// 初始化MongoDb会话对象
        /// </summary>
        /// <returns></returns>
        public async Task<IClientSessionHandle> InitTransaction() {
            return await dbContext.StartSessionAsync();
        }
    }
}
