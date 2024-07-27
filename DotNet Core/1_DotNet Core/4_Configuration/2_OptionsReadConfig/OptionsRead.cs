using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_Core._4_Configuration._2_OptionsReadConfig; 

public class OptionsRead {
    public void Use() {
        ServiceCollection services = new ServiceCollection();
        services.AddScoped<OptionsController>();
        
        ConfigurationBuilder configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("D:\\Programming\\C#\\C#Frame\\DotNet Core\\DotNet Core\\4_Configuration\\config.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configRoot = configBuilder.Build();

        services.AddOptions().Configure<Config>(e => configRoot.Bind(e));
        using var sp = services.BuildServiceProvider();
        var controller = sp.GetRequiredService<OptionsController>();
        controller.Test();
    }
}