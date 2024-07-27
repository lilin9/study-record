using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace DotNet_Core._5_Logging._2_TextLogging; 

public class TextLogging {
    public void Use() {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(loggingBuilder => {
            loggingBuilder.AddConsole();
            //设置显示出来的日志级别
            loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            //添加日志信息到文本文件里面
            loggingBuilder.AddNLog();
        });
        serviceCollection.AddScoped<LoggingTest>();

        using var provider = serviceCollection.BuildServiceProvider();
        var loggingTest = provider.GetRequiredService<LoggingTest>();
        loggingTest.Test();
    }
}