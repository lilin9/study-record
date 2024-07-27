using Microsoft.AspNetCore.Mvc;
using UserMgr.Domain;
using UserMgr.Infrastructure;

namespace UserMgr.WebAPI.Controller;

[Route("/api/login")]
[ApiController]
public class LoginController(UserDomainService userService) : ControllerBase {

    [HttpPost]
    [UnitOfWork([typeof(MySqlDbContext)])]
    public async Task<ActionResult> LoginByPhoneAndPassword(LoginByPhoneAndPasswordRequest req) {
        if (req.Password.Length < 3) {
            return BadRequest("密码长度必须大于3");
        }

        var result = await userService.CheckPassword(req.PhoneNumber, req.Password);
        switch (result) {
            case UserAccessResult.Ok:
                return Ok("登录成功");
            case UserAccessResult.PasswordError:
            case UserAccessResult.NoPassword:
            case UserAccessResult.PhoneNumberNotFound:
                return BadRequest("登录失败");
            case UserAccessResult.Lockout:
                return BadRequest("账户被锁定");
            default:
                throw new ApplicationException($"未知值{result}");
        }

    }
}
    