using Microsoft.Extensions.Options;

namespace DotNet_Core._4_Configuration._2_OptionsReadConfig; 

//选项读取配置，通过自动注入方式
public class OptionsController {
    private readonly IOptionsSnapshot<Config> _optConfig;

    public OptionsController(IOptionsSnapshot<Config> optConfig) {
        _optConfig = optConfig;
    }

    public void Test() {
        Console.WriteLine("name = " + _optConfig.Value.Name);
        Console.WriteLine("age = " + _optConfig.Value.Age);
    }
}