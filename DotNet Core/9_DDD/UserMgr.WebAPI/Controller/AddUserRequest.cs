using UserMgr.Domain.ValueObject;

namespace UserMgr.WebAPI.Controller;

public record AddUserRequest(PhoneNumber PhoneNumber, string Password);