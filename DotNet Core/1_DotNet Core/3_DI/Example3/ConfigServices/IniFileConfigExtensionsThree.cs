using DotNet_Core._3_DI.Example3.ConfigServices;

namespace Microsoft.Extensions.DependencyInjection;

public static class IniFileConfigExtensionsThree {
    public static void AddIniFileConfigThree(this IServiceCollection services, string filePath) {
        services.AddScoped(typeof(IConfigService),
            s => new IniFileConfigService { FilePath = filePath });
    }
}