using DotNet_Core._3_DI.Example3.ConfigServices;
using DotNet_Core._3_DI.Example3.MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_Core._3_DI.Example3; 

public class ExampleMain {
    public void Use() {
        var service = new ServiceCollection();

        service.AddScoped<IConfigService, EnvarConfigService>();
        service.AddLayeredConfigThree();
        service.AddIniFileConfigThree("D:\\Programming\\C#\\C#Frame\\DotNet Core\\DotNet Core\\3_DI\\Example3\\mail.ini");
        service.AddConsoleLogThree();
        service.AddScoped<IMailService, MailService>();

        using var sp = service.BuildServiceProvider();
        var mailService = sp.GetRequiredService<IMailService>();
        mailService.Send("Hello Fuck World", "god@tiantang.com", "I love this fuck world!");
    }
}