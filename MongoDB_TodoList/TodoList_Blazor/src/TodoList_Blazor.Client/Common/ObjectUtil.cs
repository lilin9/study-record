using System.Text.Json;

namespace TodoList_Blazor.Client.Common
{
    /// <summary>
    /// 类操作有关的工具类
    /// </summary>
    public static class ObjectUtil
    {
        /// <summary>
        /// 对一个对象实现深拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T? DeepCopy<T>(T? obj)
        {
            if (obj == null)
            {
                return obj;
            }

            var formatter = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(formatter);
        }

        /// <summary>
        /// 类转换，将一个类转换成另一个类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TQ"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TQ ObjectCopy<T, TQ>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return (TQ)Convert.ChangeType(obj, typeof(TQ));
        }
    }
}
