using Domain.Models;

namespace Domain.Interfaces {
    public interface IStudentRepository: IRepository<Student> {
        /// <summary>
        /// 根据 email 查找
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Student GetByEmail(string email);
    }
}
