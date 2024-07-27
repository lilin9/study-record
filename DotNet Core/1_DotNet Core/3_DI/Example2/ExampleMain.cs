using DotNet_Core._3_DI.Example2.MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_Core._3_DI.Example2; 

public class ExampleMain {
    public void Use() {
        var service = new ServiceCollection();

        // service.AddScoped<IConfigService, EnvarConfigService>();
        // service.AddScoped(typeof(IConfigService),
        //     it => new IniFileConfigService {FilePath = "D:\\Programming\\C#\\C#Frame\\DotNet Core\\DotNet Core\\3_DI\\Example1\\mail.ini"});
        service.AddIniFileConfig("D:\\Programming\\C#\\C#Frame\\DotNet Core\\DotNet Core\\3_DI\\Example1\\mail.ini");
        // service.AddScoped<ILogProvider, ConsoleLogProvider>();
        service.AddConsoleLog();
        service.AddScoped<IMailService, MailService>();

        using var sp = service.BuildServiceProvider();
        var mailService = sp.GetRequiredService<IMailService>();
        mailService.Send("Hello Fuck World", "god@tiantang.com", "I love this fuck world!");
    }
}