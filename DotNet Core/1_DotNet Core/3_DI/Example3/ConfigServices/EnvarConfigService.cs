namespace DotNet_Core._3_DI.Example3.ConfigServices; 

public class EnvarConfigService: IConfigService {
    public string? GetValue(string name) {
        return Environment.GetEnvironmentVariable(name);
    }
}