using Microsoft.AspNetCore.Mvc;
using UserMgr.Domain;
using UserMgr.Infrastructure;

namespace UserMgr.WebAPI.Controller;

[ApiController]
[Route("/api/[controller]/[action]")]
public class CrudController(IUserRepository userRepository, MySqlDbContext dbContext): ControllerBase {
    
    [HttpPost]
    [UnitOfWork([typeof(MySqlDbContext)])]
    public async Task<IActionResult> AddNewUser(AddUserRequest req) {
        if (await userRepository.FindOneAsync(req.PhoneNumber) != null) {
            return BadRequest("手机号已经存在");
        }

        var user = new Domain.Entities.User(req.PhoneNumber);
        user.ChangePassword(req.Password);
        dbContext.Users.Add(user);
        return Ok("添加成功");
    }
}









