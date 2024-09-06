namespace Domain.Core.Commands.Student
{
    /// <summary>
    /// 定义一个抽象 StudentCommand 命令模型，继承 Command
    /// 这个模型主要作用是创建命令动作，而不是用来实例化存储数据，所以是一个抽象类
    /// </summary>
    public abstract class StudentCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public string Phone { get; protected set; }
    }
}
