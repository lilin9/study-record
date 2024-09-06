using Application.ViewModels;

namespace Application.Interfaces {
    /// <summary>
    /// 定义 ICustomerAppService 服务接口
    /// 并且继承 IDisposable 接口，显示释放资源
    /// </summary>
    public interface IStudentAppService: IDisposable {
        void Register(StudentViewModel  studentViewModel);
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetById(Guid id);
        void Update(StudentViewModel customViewModel);
        void Delete(Guid id);
    }
}
