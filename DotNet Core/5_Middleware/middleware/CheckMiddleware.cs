using Dynamic.Json;

namespace _5_Middleware;

public class CheckMiddleware {
    private readonly RequestDelegate _next;

    public CheckMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        var password = context.Request.Query["password"];
        if ("123".Equals(password)) {
            if (context.Request.HasJsonContentType()) {
                var stream = context.Request.BodyReader.AsStream();
                dynamic? obj = DJson.ParseAsync(stream);
                context.Items["BodyJson"] = obj;
            }

            await _next.Invoke(context);
        } else {
            context.Response.StatusCode = 401;
        }
    }
}