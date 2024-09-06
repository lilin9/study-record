namespace Domain.Core.Events.Student {
    /// <summary>
    /// student 被修改后引发的事件，继承事件基类标识
    ///
    /// 构造函数初始化，整个事件是一个值对象
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="birthDate"></param>
    /// <param name="phone"></param>
    public class StudentUpdatedEvent(Guid id, string name, string email, DateTime birthDate, string phone)
        : Event {
        public Guid Id { get; set; } = id;
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public DateTime BirthDate { get; private set; } = birthDate;
        public string Phone { get; private set; } = phone;
    }
}
