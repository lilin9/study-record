using DotNet_Core._4_Configuration._2_OptionsReadConfig;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_Core._4_Configuration._4_CustomConfig; 

public class CustomConfig {
    public void Use() {
        ServiceCollection services = new ServiceCollection();
        services.AddScoped<CustomController>();
        
        ConfigurationBuilder configBuilder = new ConfigurationBuilder();
        configBuilder.Add(new CustomConfigSource() { Path = "web.config" });

        var configRoot = configBuilder.Build();
        services.AddOptions().Configure<WebConfig>(e => configRoot.Bind(e));

        using var sp = services.BuildServiceProvider();
        var controller = sp.GetRequiredService<OptionsController>();
        controller.Test();
    }
}









