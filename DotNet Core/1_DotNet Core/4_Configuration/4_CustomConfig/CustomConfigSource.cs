using Microsoft.Extensions.Configuration;

namespace DotNet_Core._4_Configuration._4_CustomConfig; 

public class CustomConfigSource: FileConfigurationSource {
    public override IConfigurationProvider Build(IConfigurationBuilder builder) {
        EnsureDefaults(builder);    //处理 path 路径默认值问题
        return new CustomConfigProvider(this);
    }
}