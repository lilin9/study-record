using Domain.Core.Models;

namespace Domain.Models {
    public class Student: Entity {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Phone { get; private set; }
        public Address Address { get; private set; }

        protected Student() { }

        public Student(Guid id, string name, string email, DateTime birthDate, string phone) {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
        }
    }
}
