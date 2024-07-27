using Microsoft.AspNetCore.Mvc.Filters;

namespace _4_Filter.filter; 

public class MyActionFilter: IAsyncActionFilter {
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
        Console.WriteLine("MyActionFilter 执行前");
        var result = await next();
        //判断是否执行成功
        if (result.Exception != null) {
            Console.WriteLine("MyActionFilter 执行失败\n" + result.Exception.Message);
        } else {
            Console.WriteLine("MyActionFilter 执行成功");
        }
    }
}