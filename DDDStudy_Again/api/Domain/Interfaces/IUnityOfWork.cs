namespace Domain.Interfaces {
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnityOfWork: IDisposable {
        /// <summary>
        /// 是否提交成功
        /// </summary>
        /// <returns></returns>
        bool Commit();
    }
}
