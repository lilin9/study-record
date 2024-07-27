using UserMgr.Domain.ValueObject;

namespace UserMgr.Domain;

public interface ISmsCodeSender {
    Task SendAsync(PhoneNumber phoneNumber, string code);
}