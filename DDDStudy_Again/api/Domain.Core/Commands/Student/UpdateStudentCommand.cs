﻿using Domain.Core.Validations;
using MediatR;

namespace Domain.Core.Commands.Student {
    public class UpdateStudentCommand: StudentCommand, IRequest<Unit> {
        /// <summary>
        /// set 设置为 protected，只能通过构造方法赋值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="birthDate"></param>
        /// <param name="phone"></param>
        public UpdateStudentCommand(string name, string email, DateTime birthDate, string phone) {
            Name = name; Email = email; BirthDate = birthDate; Phone = phone; 
        }

        /// <summary>
        /// 主要是为了引入命令验证 RegisterStudentCommandValidation
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool IsValid() {
            //进行命令验证
            ValidationResult = new UpdateStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
