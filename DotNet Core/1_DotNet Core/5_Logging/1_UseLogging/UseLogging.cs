using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNet_Core._5_Logging._1_UseLogging; 

public class UseLogging {
    public void Use() {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(loggingBuilder => {
            loggingBuilder.AddConsole();
            //设置显示出来的日志级别
            loggingBuilder.SetMinimumLevel(LogLevel.Trace);
        });
        serviceCollection.AddScoped<LoggingTest>();

        using var provider = serviceCollection.BuildServiceProvider();
        var loggingTest = provider.GetRequiredService<LoggingTest>();
        loggingTest.Test();
    }
}