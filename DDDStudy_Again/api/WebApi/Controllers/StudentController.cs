using Application.Interfaces;
using Application.ViewModels;
using Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController(
        INotificationHandler<DomainNotification> notification,
        IStudentAppService studentAppService)
        : ControllerBase {
        private readonly DomainNotificationHandler _notification = (DomainNotificationHandler) notification;

        [HttpGet]
        public ActionResult<IEnumerable<StudentViewModel>> GetAll() {
            return Ok(studentAppService.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentViewModel) {
            try {
                // //清空缓存
                // cache.Remove("ErrorData");
                // //视图模型验证
                // if (!ModelState.IsValid) {
                //     return BadRequest(ModelState);
                // }

                //调用添加方法
                studentAppService.Register(studentViewModel);

                //是否存在消息通知
                if (!_notification.HasNotifications()) {
                    return BadRequest("Student Registered");
                }
                return Ok();
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
