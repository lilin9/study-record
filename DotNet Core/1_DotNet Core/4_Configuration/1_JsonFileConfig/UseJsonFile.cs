using Microsoft.Extensions.Configuration;

namespace DotNet_Core._4_Configuration._1_JsonFileConfig; 

public class UseJsonFile {
    public void Use() {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("D:\\Programming\\C#\\C#Frame\\DotNet Core\\DotNet Core\\4_Configuration\\config.json", optional: true, reloadOnChange: true);
        var configRoot = builder.Build();

        // var name = configRoot["name"];
        // var address = configRoot.GetSection("proxy")["address"];
        //
        // Console.WriteLine($"name = {name}");
        // Console.WriteLine($"address = {address}");

        var config = configRoot.Get<Config>();
        Console.WriteLine(config?.Name);
        Console.WriteLine(config?.Proxy.Port);
    }
}



