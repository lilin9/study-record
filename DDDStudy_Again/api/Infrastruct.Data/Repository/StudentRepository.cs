using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.Repository
{
    public class StudentRepository(StudentContext context) : 
        Repository<Student>(context), IStudentRepository {

        public Student GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
