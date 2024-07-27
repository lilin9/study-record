using UserMgr.Domain.Entities;
using UserMgr.Domain.ValueObject;

namespace UserMgr.Domain;

public class UserDomainService {
    private IUserRepository _userRepository;
    private ISmsCodeSender _smsCodeSender;

    public UserDomainService(IUserRepository userRepository, ISmsCodeSender smsCodeSender) {
        _userRepository = userRepository;
        _smsCodeSender = smsCodeSender;
    }

    public void ResetAccessFail(User user) {
        user.UserAccessFail.Reset();
    }

    public bool IsLockOut(User user) {
        return user.UserAccessFail.IsLockOut();
    }

    public void AccessFail(User user) {
        user.UserAccessFail.Fail();
    }

    public async Task<UserAccessResult?> CheckPassword(PhoneNumber phoneNumber, string password) {
        UserAccessResult result;
        var user = await _userRepository.FindOneAsync(phoneNumber);
        if (user == null) {
            result = UserAccessResult.PhoneNumberNotFound;
        } else if (IsLockOut(user)) {
            result = UserAccessResult.Lockout;
        } else if (!user.HasPassword()) {
            result = UserAccessResult.NoPassword;
        } else if (user.CheckPassword(password)) {
            result = UserAccessResult.Ok;
        } else {
            result = UserAccessResult.PasswordError;
        }

        if (user != null) {
            if (result == UserAccessResult.Ok) {
                ResetAccessFail(user);
            } else {
                AccessFail(user);
            }
        }

        await _userRepository.PublishEventAsync(new UserAccessResultEvent(phoneNumber, result));
        return result;
    }

    public async Task<CheckCodeResult> CheckPhoneNumberCodeAsync(PhoneNumber phoneNumber, string code) {
        var user = await _userRepository.FindOneAsync(phoneNumber);
        if (user == null) {
            return CheckCodeResult.PhoneNumberNotFound;
        } else if (IsLockOut(user)) {
            return CheckCodeResult.Lockout;
        }

        var codeInServer = await _userRepository.FindPhoneNumberCodeAsync(phoneNumber);
        if (codeInServer != null) {
            AccessFail(user);
            return CheckCodeResult.CodeError;
        }

        if (codeInServer == code) {
            return CheckCodeResult.Ok;
        } else {
            AccessFail(user);
            return CheckCodeResult.CodeError;
        }
    }
}








