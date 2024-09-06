namespace Domain.Models {
    /// <summary>
    /// 值对象基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> where T:ValueObject<T> {
        protected abstract bool EqualsCore(T other);
       /// <summary>
        /// 重写方法 相等运算
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) {
            var valueObject = obj as T;
            return !ReferenceEquals(valueObject, null) && EqualsCore(valueObject);
        }

       protected abstract int GetHashCodeCore();
       /// <summary>
       /// 获取哈希值
       /// </summary>
       /// <returns></returns>
       public override int GetHashCode() {
           return GetHashCodeCore();
       }

       /// <summary>
       /// 重写 == 运算符
       /// </summary>
       /// <param name="a"></param>
       /// <param name="b"></param>
       /// <returns></returns>
       public static bool operator ==(ValueObject<T> a, ValueObject<T> b) {
           if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) {
               return true;
           }

           if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) {
               return false;
           }

           return a.Equals(b);
       }

       /// <summary>
       /// 重写 != 运算符
       /// </summary>
       /// <param name="a"></param>
       /// <param name="b"></param>
       /// <returns></returns>
       public static bool operator !=(ValueObject<T> a, ValueObject<T> b) {
           return !(a == b);
       }

       /// <summary>
       /// 对克隆方法重写
       /// </summary>
       /// <returns></returns>
       public virtual T Clone() {
           return (T)MemberwiseClone();
       }
    }
}
