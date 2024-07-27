using DotNet_Core._3_DI.Example3.ConfigServices;

namespace Microsoft.Extensions.DependencyInjection; 

public static class LayeredConfigExtensionsThree {
    public static void AddLayeredConfigThree(this IServiceCollection services) {
        services.AddScoped<IConfigReader, LayeredConfigReader>();
    }
}