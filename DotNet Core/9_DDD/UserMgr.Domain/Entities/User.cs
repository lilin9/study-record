using NETCore.Encrypt;
using UserMgr.Domain.ValueObject;

namespace UserMgr.Domain.Entities;

public record User : IAggregateRoot {
    public Guid Id { get; init; }
    public PhoneNumber PhoneNumber { get; private set; }
    private string? passwordHash;
    public UserAccessFail UserAccessFail { get; private set; }

    public User() {
    }

    public User(PhoneNumber phoneNumber) {
        PhoneNumber = phoneNumber;
        Id = Guid.NewGuid();
        UserAccessFail = new UserAccessFail(this);
    }

    public bool HasPassword() {
        return !string.IsNullOrEmpty(passwordHash);
    }

    public void ChangePassword(string password) {
        if (password.Length <= 3) {
            throw new ArgumentException("密码长度必须大于3");
        }

        passwordHash = EncryptProvider.Md5(password);
    }

    public bool CheckPassword(string password) {
        return passwordHash == EncryptProvider.Md5(password);
    }

    public void ChangePhoneNumber(PhoneNumber phoneNumber) {
        PhoneNumber = phoneNumber;
    }
}