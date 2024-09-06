namespace Domain.Core.Models {
    /// <summary>
    /// 领域实体基类
    /// </summary>
    public abstract class Entity {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// 重写 Equals 方法，比较两个实体类是否相等
        /// 根据 Id 判断
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) {
            var compareTo = obj as Entity;

            //两个实体索引相同，就属于同一个实体
            if (ReferenceEquals(this, compareTo)) {
                return true;
            }
            return !ReferenceEquals(null, compareTo) &&
                   //再根据Id判断是否相同
                   Id.Equals(compareTo.Id);
        }

        /// <summary>
        /// 对实体比较的 == 进行重写
        /// </summary>
        /// <param name="a">领域实体a</param>
        /// <param name="b">领域实体b</param>
        /// <returns></returns>
        public static bool operator ==(Entity a, Entity b) {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) {
                return false;
            }

            return a.Equals(b);
        }

        /// <summary>
        /// != 重写
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Entity a, Entity b) {
            return !(a == b);
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        /// <summary>
        /// 重写领域对象的打印
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return GetType().Name + " [Id=]" + Id + "]";
        }
    }
}
