using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace UserMgr.WebAPI;

public class UnitOfWorkFilter : IAsyncActionFilter {
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
        var result = await next();
        //只有 Action 执行成功，没有抛出异常信息，才允许自动调用 SaveChanges
        if (result.Exception != null) {
            return;
        }

        if (context.ActionDescriptor is not ControllerActionDescriptor actionDesc) {
            return;
        }

        var uowAttr = actionDesc.MethodInfo.GetCustomAttribute<UnitOfWorkAttribute>();
        if (uowAttr == null) {
            return;
        }

        foreach (var contextType in uowAttr.DbContextTypes) {
            var dbContext = context.HttpContext.RequestServices.GetService(contextType) as DbContext;
            if (dbContext != null) {
                await dbContext.SaveChangesAsync();
            }
        }
    }
}