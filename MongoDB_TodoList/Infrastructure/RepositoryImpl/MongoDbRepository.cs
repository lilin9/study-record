using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Domain;
using Domain.Repository;
using Infrastructure.Extensions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.RepositoryImpl {
    public class MongoDbRepository<T>: IMongoDbRepository<T> where T : class, new() {
        private readonly IMongoCollection<T> _dbSet;
        private readonly IMongoDbContext _context;

        protected MongoDbRepository(IMongoDbContext context) {
            _context = context;
            var collectionName = typeof(T).GetAttributeValue((TableAttribute m) => m.Name) ?? typeof(T).Name;
            _dbSet = _context.GetCollection<T>(collectionName);
        }


        #region 事务操作

        /// <summary>
        /// 添加事务数据
        /// </summary>
        /// <param name="session">mongodb会话</param>
        /// <param name="objData">需要添加的数据</param>
        /// <returns></returns>
        public async Task AddTransactionsAsync(IClientSessionHandle session, T objData) {
            await _context.AddCommandAsync(async _ => await _dbSet.InsertOneAsync(objData));
        }

        /// <summary>
        /// 删除事务
        /// </summary>
        /// <param name="session">mongo会话</param>
        /// <param name="id">objectId</param>
        /// <returns></returns>
        public async Task DeleteTransactionsAsync(IClientSessionHandle session, string id) {
            await _context.AddCommandAsync(_ => _dbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
        }

        /// <summary>
        /// 更新单个事务
        /// </summary>
        /// <param name="session">mongo会话</param>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新条件</param>
        /// <returns></returns>
        public async Task UpdateTransactionsAsync(IClientSessionHandle session, FilterDefinition<T> filter, UpdateDefinition<T> update) {
            await _context.AddCommandAsync(_ => _dbSet.UpdateOneAsync(filter, update));
        }

        #endregion

        #region 添加相关

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="objData"></param>
        /// <returns></returns>
        public async Task AddAsync(T objData) {
            await _dbSet.InsertOneAsync(objData);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task InsertManyAsync(List<T> list) {
            await _dbSet.InsertManyAsync(list);
        }

        /// <summary>
        /// 删除，根据id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id) {
            await _dbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)));
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="filter">删除条件</param>
        /// <returns></returns>
        public async Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter) {
            return await _dbSet.DeleteManyAsync(filter);
        }

        #endregion

        #region 修改相关

        /// <summary>
        /// 修改一条
        /// </summary>
        /// <param name="data">需要更新成的数据</param>
        /// <param name="id">修改数据的Id</param>
        /// <returns></returns>
        public async Task UpdateAsync(T data, string id) {
            //修改条件
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            //获取数据中需要修改的字段
            var list = new List<UpdateDefinition<T>>();
            foreach (var property in data.GetType().GetProperties()) {
                if (property.Name.ToLower() == "id") {
                    continue;
                }
                list.Add(Builders<T>.Update.Set(property.Name, property.GetValue(data)));
            }

            var updateFilter = Builders<T>.Update.Combine(list);
            await _dbSet.UpdateOneAsync(filter, updateFilter);
        }

        /// <summary>
        /// 自定义筛选条件去更新
        /// &lt;para&gt;&lt;![CDATA[expression 参数示例：x =&gt; x.Id == 1 &amp;&amp; x.Age &gt; 18 &amp;&amp; x.Gender == 0]]&gt;&lt;/para&gt;
        /// &lt;para&gt;&lt;![CDATA[entity 参数示例：y =&gt; new T{ RealName = "Ray", Gender = 1}]]&gt;&lt;/para&gt;
        /// </summary>
        /// <param name="expression">筛选条件</param>
        /// <param name="entity">更新条件</param>
        /// <returns></returns>
        public async Task UpdateAsync(Expression<Func<T, bool>> expression, Expression<Action<T>> entity) {
            var fieldList = new List<UpdateDefinition<T>>();
            if (entity.Body is MemberInitExpression param) {
                foreach (var item in param.Bindings) {
                    var propertyName = item.Member.Name;
                    object? propertyValue = null;

                    if (item is not MemberAssignment memberAssignment) {
                        continue;
                    }

                    if (memberAssignment.Expression.NodeType == ExpressionType.Constant) {
                        if (memberAssignment.Expression is ConstantExpression constantExpression) {
                            propertyValue = constantExpression.Value;
                        }
                    } else {
                        propertyValue = Expression.Lambda(memberAssignment.Expression, null).Compile().DynamicInvoke();
                    }

                    //不是_id主键的字段才可以允许更新
                    if (propertyName != "_id") {
                        fieldList.Add(Builders<T>.Update.Set(propertyName, propertyValue));
                    }
                }
            }

            await _dbSet.UpdateOneAsync(expression, Builders<T>.Update.Combine(fieldList));
        }

        /// <summary>
        /// 自定义筛选条件去更新
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新条件</param>
        /// <returns></returns>
        public async Task UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> update) {
            await _dbSet.UpdateOneAsync(filter, update);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="expression">筛选条件</param>
        /// <param name="update">更新条件</param>
        /// <returns></returns>
        public async Task UpdateManyAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> update) {
            await _dbSet.UpdateManyAsync(expression, update);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="dic">需要修改的字段</param>
        /// <param name="filter">更新条件</param>
        /// <returns></returns>
        public async Task<UpdateResult> UpdateManyAsync(Dictionary<string, string> dic, FilterDefinition<T> filter) {
            var t = new T();
            //获取需要修改的字段
            var list = new List<UpdateDefinition<T>>();
            foreach (var item in t.GetType().GetProperties()) {
                if (!dic.TryGetValue(item.Name, out var value)) {
                    continue;
                }

                list.Add(Builders<T>.Update.Set(item.Name, value));
            }

            var updateFilter = Builders<T>.Update.Combine(list);
            return await _dbSet.UpdateManyAsync(filter, updateFilter);
        }

        #endregion

        #region 查询相关

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(string id) {
            var result = await _dbSet.FindAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)));
            return result.FirstOrDefault();
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync() {
            var result = await _dbSet.FindAsync(Builders<T>.Filter.Empty);
            return result.ToList();
        }

        /// <summary>
        /// 根据条件统计查询出来的个数
        /// </summary>
        /// <param name="expression">筛选方法</param>
        /// <returns></returns>
        public async Task<long> CountAsync(Expression<Func<T, bool>> expression) {
            return await _dbSet.CountDocumentsAsync(expression);
        }

        /// <summary>
        /// 根据过滤器统计查询出来的个数
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public async Task<long> CountAsync(FilterDefinition<T> filter) {
            return await _dbSet.CountDocumentsAsync(filter);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="predicate">判断条件</param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) {
            return await Task.FromResult(_dbSet.AsQueryable().Any(predicate));
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="fields">需要查询的字段，无则查询所有</param>
        /// <param name="sort">需要排序的字段</param>
        /// <returns></returns>
        public async Task<List<T>> FindListAsync(FilterDefinition<T> filter, string[]? fields = null, SortDefinition<T>? sort = null) {
            //没有查询指定字段时，走以下逻辑
            if (fields == null || fields.Length == 0) {
                if (sort == null) {
                    return await _dbSet.Find(filter).ToListAsync();
                }

                return await _dbSet.Find(filter).Sort(sort).ToListAsync();
            }

            //需要查询指定字段时，走如下逻辑
            var fieldList = fields.Select(t => Builders<T>
                .Projection.Include(t.ToString())).ToList();

            //查询指定字段的列表数据m
            var projection = Builders<T>.Projection.Combine(fieldList);
            fieldList?.Clear();

            if (sort != null) {
                return await _dbSet.Find(filter).Sort(sort).Project<T>(projection).ToListAsync();
            }
            return await _dbSet.Find(filter).Project<T>(projection).ToListAsync();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">当前页大小</param>
        /// <param name="fields">需要查询的字段，无则查询所有</param>
        /// <param name="sort">需要排序的字段</param>
        /// <returns></returns>
        public async Task<List<T>> FindListByPageAsync(FilterDefinition<T> filter, int pageIndex, int pageSize, string[]? fields = null,
            SortDefinition<T>? sort = null) {
            //没有指定查询字段时
            if (fields == null || fields.Length == 0) {
                if (sort == null) {
                    return await _dbSet.Find(filter)
                        .Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
                }
                return await _dbSet.Find(filter).Sort(sort)
                    .Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
            }

            //指定查询字段
            var fieldList = fields.Select(t => Builders<T>.Projection
                .Include(t.ToString())).ToList();
            var projections = Builders<T>.Projection.Combine(fieldList);
            fieldList.Clear();

            if (sort == null) {
                return await _dbSet.Find(filter).Project<T>(projections)
                    .Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
            }
            return await _dbSet.Find(filter).Sort(sort).Project<T>(projections)
                .Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
        }

        #endregion
    }
}
