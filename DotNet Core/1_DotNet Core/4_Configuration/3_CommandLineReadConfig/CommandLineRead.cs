using DotNet_Core._4_Configuration._2_OptionsReadConfig;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_Core._4_Configuration._3_CommandLineReadConfig; 

public class CommandLineRead {
    public void Use(string[] args) {
        // ServiceCollection services = new ServiceCollection();
        // services.AddScoped<OptionsController>();
        //
        // ConfigurationBuilder configBuilder = new ConfigurationBuilder();
        // configBuilder.AddCommandLine(args);
        // IConfigurationRoot configRoot = configBuilder.Build();
        //
        // services.AddOptions().Configure<Config>(e => configRoot.Bind(e));
        // using var sp = services.BuildServiceProvider();
        // var controller = sp.GetRequiredService<OptionsController>();
        // controller.Test();
    }
}