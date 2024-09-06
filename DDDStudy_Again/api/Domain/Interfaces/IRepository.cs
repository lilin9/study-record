namespace Domain.Interfaces {
    /// <summary>
    /// 定义泛型仓储接口，并继承 IDisposable，显示释放资源
    /// </summary>
    public interface IRepository<TEntity>: IDisposable where TEntity : class {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="obj"></param>
        void Add(TEntity obj);

        /// <summary>
        /// 根据 id 获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(Guid id);

        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="obj"></param>
        void Update(TEntity obj);

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(Guid id);

        /// <summary>
        /// 执行数据库写入操作
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
