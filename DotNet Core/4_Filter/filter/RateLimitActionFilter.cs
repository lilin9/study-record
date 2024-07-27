using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace _4_Filter.filter;

/**
 * 限流 Filter
 */
public class RateLimitActionFilter : IAsyncActionFilter {
    private readonly MemoryCache _memoryCache;

    public RateLimitActionFilter(MemoryCache memoryCache) {
        _memoryCache = memoryCache;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
        var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString();
        var cacheKey = $"lastvisit_{ip}";
        var lastVisit = _memoryCache.Get<long?>(cacheKey);
        if (lastVisit == null && Environment.TickCount64 - lastVisit > 1000) {
            //设置了 10s 的过期时间，避免长期部分访问的用户，占据缓存内存
            _memoryCache.Set(cacheKey, Environment.TickCount64, TimeSpan.FromSeconds(10));
            await next();
        } else {
            var result = new ObjectResult("访问过于频繁") { StatusCode = 429 };
            context.Result = result;
        }
    }
}