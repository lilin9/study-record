using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;

namespace DotNet_Core._5_Logging._3_Serilog; 

public class Serilog {
    public void Use() {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(loggingBuilder => {
            //配置 serilog 信息
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console(new JsonFormatter())
                .CreateLogger();
            loggingBuilder.AddSerilog();
        });
        serviceCollection.AddScoped<LoggingTest>();

        using var provider = serviceCollection.BuildServiceProvider();
        var loggingTest = provider.GetRequiredService<LoggingTest>();
        loggingTest.Test();
    }
}