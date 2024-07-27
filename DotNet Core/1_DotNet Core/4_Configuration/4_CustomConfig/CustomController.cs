using Microsoft.Extensions.Options;

namespace DotNet_Core._4_Configuration._4_CustomConfig; 

public class CustomController {
    private readonly IOptionsSnapshot<WebConfig> _optConfig;

    public CustomController(IOptionsSnapshot<WebConfig> optConfig) {
        _optConfig = optConfig;
    }

    public void Test() {
        var value = _optConfig.Value;
        Console.WriteLine(value.Conn1.ConnectionString);
        Console.WriteLine(value.Config.Age);
        Console.WriteLine(value.Config.Proxy.Address);
    }
}