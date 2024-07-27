using _5_Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/test", myBuilder => {
    //注册自定义中间件类
    myBuilder.UseMiddleware<CheckMiddleware>();
    myBuilder.Use(async (context, next) => {
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("<p>1 start</p><br/>");
        await next.Invoke();
        await context.Response.WriteAsync("<p>1 end</p><br/>");
    });
    myBuilder.Use(async (context, next) => {
        await context.Response.WriteAsync("<p>2 start</p><br/>");
        await next.Invoke();
        await context.Response.WriteAsync("<p>2 end</p><br/>");
    });
    myBuilder.Run(async context => {
        await context.Response.WriteAsync("<p>Run</p><br/>");
         dynamic? obj = context.Items["BodyJson"];
         if (obj != null) {
             await context.Response.WriteAsync($"{obj}<br/>");
         }
    });
});

app.Run();