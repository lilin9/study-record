using DotNet_Core._3_DI.Example1.ConfigServices;
using DotNet_Core._3_DI.Example1.LogServices;
using DotNet_Core._3_DI.Example1.MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_Core._3_DI.Example1; 

public class ExampleMain {
    public void Use() {
        var service = new ServiceCollection();

        service.AddScoped<IConfigService, EnvarConfigService>();
        service.AddScoped<ILogProvider, ConsoleLogProvider>();
        service.AddScoped<IMailService, MailService>();

        using var sp = service.BuildServiceProvider();
        var mailService = sp.GetRequiredService<IMailService>();
        mailService.Send("Hello Fuck World", "god@tiantang.com", "I love this fuck world!");
    }
}