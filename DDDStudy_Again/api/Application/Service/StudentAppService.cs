using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Core.Bus;
using Domain.Interfaces;
using Domain.Models;
using Domain.Core.Commands.Student;

namespace Application.Service {
    /// <summary>
    /// StudentAppService 服务接口实现类
    /// 通过 DTO 实现视图模型和领域模型的关系处理
    /// 并且作为调度者，协调领域层和基础层
    /// </summary>
    public class StudentAppService(
        IStudentRepository studentRepository,
        IMapper mapper,
        IMediatorHandler bus): IStudentAppService {
        public void Dispose() {
            GC.SuppressFinalize(this);
        }

        public async void Register(StudentViewModel studentViewModel) {
            //TODO 这里引入领域设计中的写命令
            var registerCommand = mapper.Map<RegisterStudentCommand>(studentViewModel);
            await bus.SenderCommandAsync(registerCommand);
        }

        public IEnumerable<StudentViewModel> GetAll() {
            var students = studentRepository.GetAll();
            //使用 AutoMapper 的 Map 将 Student 转换成 StudentViewModel
            // return mapper.Map<IEnumerable<StudentViewModel>>(students);
            
            //第二种方式，使用 AutoMapper 的 ProjectTo 实现
            return students.ProjectTo<StudentViewModel>(mapper.ConfigurationProvider);
        }

        public StudentViewModel GetById(Guid id) {
            return mapper.Map<StudentViewModel>(studentRepository.GetById(id));
        }

        public void Update(StudentViewModel studentViewModel) {
            //TODO 参数校验
            studentRepository.Update(mapper.Map<Student>(studentViewModel));
        }

        public void Delete(Guid id) {
            studentRepository.DeleteById(id);
        }
    }
}
