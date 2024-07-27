using UserMgr.Domain.ValueObject;

namespace UserMgr.WebAPI.Controller;

public record LoginByPhoneAndPasswordRequest(PhoneNumber PhoneNumber, string Password);