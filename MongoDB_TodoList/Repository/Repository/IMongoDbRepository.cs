using System.Linq.Expressions;
using MongoDB.Driver;

namespace Domain.Repository {
    /// <summary>
    /// MongoDB通用型仓储，将对 MongoDB 的增、删、改、查抽象出来
    /// </summary>
    public interface IMongoDbRepository<T> where T: class, new() {
        #region 事务操作

        /// <summary>
        /// 添加事务数据
        /// </summary>
        /// <param name="session">mongodb会话</param>
        /// <param name="objData">需要添加的数据</param>
        /// <returns></returns>
        Task AddTransactionsAsync(IClientSessionHandle session, T objData);

        /// <summary>
        /// 删除事务
        /// </summary>
        /// <param name="session">mongo会话</param>
        /// <param name="id">objectId</param>
        /// <returns></returns>
        Task DeleteTransactionsAsync(IClientSessionHandle session, string id);

        /// <summary>
        /// 更新单个事务
        /// </summary>
        /// <param name="session">mongo会话</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新条件</param>
        /// <returns></returns>
        Task UpdateTransactionsAsync(IClientSessionHandle session, FilterDefinition<T> filter, UpdateDefinition<T> update);

        #endregion

        #region 添加相关

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="objData"></param>
        /// <returns></returns>
        Task AddAsync(T  objData);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task InsertManyAsync(List<T>  list);

        #endregion

        #region 删除相关

        /// <summary>
        /// 删除，根据id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="filter">删除条件</param>
        /// <returns></returns>
        Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter);

        #endregion

        #region 修改相关
        
        /// <summary>
        /// 修改一条
        /// </summary>
        /// <param name="data">需要更新成的数据</param>
        /// <param name="id">修改数据的Id</param>
        /// <returns></returns>
        Task UpdateAsync(T data, string id);

        /// <summary>
        /// 自定义筛选条件去更新
        /// &lt;para&gt;&lt;![CDATA[expression 参数示例：x =&gt; x.Id == 1 &amp;&amp; x.Age &gt; 18 &amp;&amp; x.Gender == 0]]&gt;&lt;/para&gt;
        /// &lt;para&gt;&lt;![CDATA[entity 参数示例：y =&gt; new T{ RealName = "Ray", Gender = 1}]]&gt;&lt;/para&gt;
        /// </summary>
        /// <param name="expression">筛选条件</param>
        /// <param name="entity">更新条件</param>
        /// <returns></returns>
        Task UpdateAsync(Expression<Func<T, bool>> expression, Expression<Action<T>> entity);

        /// <summary>
        /// 自定义筛选条件去更新
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新条件</param>
        /// <returns></returns>
        Task UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> update);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="expression">筛选条件</param>
        /// <param name="update">更新条件</param>
        /// <returns></returns>
        Task UpdateManyAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> update);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="dic">需要修改的字段</param>
        /// <param name="filter">更新条件</param>
        /// <returns></returns>
        Task<UpdateResult> UpdateManyAsync(Dictionary<string, string> dic, FilterDefinition<T> filter);

        #endregion

        #region 查询相关

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string id);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// 根据条件统计查询出来的个数
        /// </summary>
        /// <param name="expression">筛选方法</param>
        /// <returns></returns>
        Task<long> CountAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 根据过滤器统计查询出来的个数
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        Task<long> CountAsync(FilterDefinition<T> filter);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="predicate">判断条件</param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="fields">需要查询的字段，无则查询所有</param>
        /// <param name="sort">需要排序的字段</param>
        /// <returns></returns>
        Task<List<T>> FindListAsync(FilterDefinition<T> filter, string[]? fields = null, SortDefinition<T>? sort = null);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">当前页大小</param>
        /// <param name="fields">需要查询的字段，无则查询所有</param>
        /// <param name="sort">需要排序的字段</param>
        /// <returns></returns>
        Task<List<T>> FindListByPageAsync(FilterDefinition<T> filter, int pageIndex, int pageSize,
            string[]? fields = null, SortDefinition<T>? sort = null);

        #endregion
    }
}
