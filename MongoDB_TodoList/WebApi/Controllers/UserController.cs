using Application.Services;
using Application.ViewObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class UserController(UserServices userServices) : ControllerBase
    {

        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetAllUser()
        {
            var allUser = await userServices.GetAllUserInfo();
            return Ok(allUser);
        }

        /// <summary>
        /// 获取分页用户信息
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUserByPage([FromBody] UserPageVm vm)
        {
            var users = await userServices.GetUserInfoByPage(vm);
            return Ok(users);
        }

        /// <summary>
        /// 根据id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfoById(string id)
        {
            var userInfo = await userServices.GetUserInfoById(id);
            return Ok(userInfo);
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserInfo>> AddUserInfo([FromBody] UserVm vm)
        {
            var addUserInfo = await userServices.AddUserInfo(vm);
            return Ok(addUserInfo);
        }

        /// <summary>
        /// 事务添加用户信息
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserInfo>> AddTransactionUserInfo([FromBody] UserVm vm)
        {
            var addUserInfo = await userServices.AddTransactionUserInfo(vm);
            return Ok(addUserInfo);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<UserInfo>> UpdateUserInfo(string id, [FromBody] UserVm vm)
        {
            var updateUser = await userServices.UpdateUser(id, vm);
            return Ok(updateUser);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserInfo(string id)
        {
            var result = await userServices.Delete(id);
            return Ok(result);
        }
    }
}
