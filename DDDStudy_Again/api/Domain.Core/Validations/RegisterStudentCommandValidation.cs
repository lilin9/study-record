using Domain.Core.Commands.Student;

namespace Domain.Core.Validations {
    /// <summary>
    /// 添加学生命令模型验证
    /// 继承 StudentValidation 基类
    /// </summary>
    public class RegisterStudentCommandValidation: StudentValidation<RegisterStudentCommand> {
        public RegisterStudentCommandValidation() {
            ValidateName();     //验证姓名
            ValidateBirthDate(); //验证年龄
            ValidateEmail();    //验证邮箱
            ValidatePhone(); //验证手机号
        }
    }
}
