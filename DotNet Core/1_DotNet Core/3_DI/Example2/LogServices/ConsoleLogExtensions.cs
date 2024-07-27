using DotNet_Core._3_DI.Example2.LogServices;

namespace Microsoft.Extensions.DependencyInjection; 

public static class ConsoleLogExtensions {
    public static void AddConsoleLog(this IServiceCollection services) {
        services.AddScoped<ILogProvider, ConsoleLogProvider>();
    }
}