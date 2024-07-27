using DotNet_Core._3_DI.Example3.LogServices;

namespace Microsoft.Extensions.DependencyInjection; 

public static class ConsoleLogExtensionsThree {
    public static void AddConsoleLogThree(this IServiceCollection services) {
        services.AddScoped<ILogProvider, ConsoleLogProvider>();
    }
}