using UserMgr.Domain;
using UserMgr.Domain.ValueObject;

namespace UserMgr.Infrastructure;

public class MockSmsCodeSender: ISmsCodeSender {
    public Task SendAsync(PhoneNumber phoneNumber, string code) {
        Console.WriteLine($"向{phoneNumber.RegionNumber}-{phoneNumber.Number}发送验证码{code}");
        return Task.CompletedTask;
    }
}







