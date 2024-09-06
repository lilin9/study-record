using Domain.Core.Commands.Student;
using FluentValidation;

namespace Domain.Core.Validations {
    /// <summary>
    /// 定义基于 StudentCommand 的抽象基类StudentValidation，
    /// 去继承抽象类 AbstractValidator
    /// 注意：需要引用 FluentValidation
    /// 注意：这里的 T 是命令模型
    /// </summary>
    /// <typeparam name="T">泛型类</typeparam>
    public abstract class StudentValidation<T>: AbstractValidator<T> where T: StudentCommand {
        /// <summary>
        /// 验证Name
        /// </summary>
        protected void ValidateName() {
            //定义规则
            //姓名不能为空，限制姓名长度
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("姓名不能为空")
                .Length(2, 10).WithMessage("姓名在2~10个字符之间");
        }

        /// <summary>
        /// 验证年龄
        /// </summary>
        protected void ValidateBirthDate() {
            //年龄不能为空
            //年龄要大于14岁
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("学生年龄应该14岁以上");
        }

        /// <summary>
        /// 验证邮箱
        /// </summary>
        protected void ValidateEmail() {
            //邮箱不能为空
            //邮箱格式正确
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        /// <summary>
        /// 验证手机号
        /// </summary>
        protected void ValidatePhone() {
            //手机号不能为空
            //手机号格式正确
            RuleFor(c => c.Phone)
                .NotEmpty()
                .Must(HavePhone)
                .WithMessage("手机号应该11位");
        }

        /// <summary>
        /// 验证Id
        /// </summary>
        protected void ValidateId() {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        /// <summary>
        /// 年龄要大于14岁
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        protected static bool HaveMinimumAge(DateTime birthDate) {
            return birthDate <= DateTime.Now.AddYears(-14);
        }

        /// <summary>
        /// 手机号长度在11位之间
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        protected static bool HavePhone(string phone) {
            return phone.Length == 11;
        }
    }
}
