using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _4_Filter.filter; 

public class MyExceptionFilter: IAsyncExceptionFilter {
    private readonly IWebHostEnvironment _hostEnv;

    public MyExceptionFilter(IWebHostEnvironment hostEnv) {
        _hostEnv = hostEnv;
    }

    public Task OnExceptionAsync(ExceptionContext context) {
        //context.Exception 代表异常信息对象
        //如果给 context.ExceptionHandled 赋值为 true，则其他 ExceptionFilter 不会再执行
        //context.Result 的值会被输出给客户端
        string msg;
        //判断是不是生产环境
        if (_hostEnv.IsDevelopment()) {
            msg = context.Exception.Message;
        } else {
            msg = "服务端发生未处理异常";
        }

        var objectResult = new ObjectResult(new {code=500, message=msg});
        context.Result = objectResult;
        context.ExceptionHandled = true;
        context.Result = objectResult;
        return Task.CompletedTask;

    }
}