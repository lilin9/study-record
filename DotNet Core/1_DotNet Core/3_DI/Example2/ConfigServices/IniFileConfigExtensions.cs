using DotNet_Core._3_DI.Example2.ConfigServices;

namespace Microsoft.Extensions.DependencyInjection;

public static class IniFileConfigExtensions {
    public static void AddIniFileConfig(this IServiceCollection services, string filePath) {
        services.AddScoped(typeof(IConfigService),
            s => new IniFileConfigService { FilePath = filePath });
    }
}