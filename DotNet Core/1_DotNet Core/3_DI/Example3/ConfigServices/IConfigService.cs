namespace DotNet_Core._3_DI.Example3.ConfigServices; 

public interface IConfigService {
    public string? GetValue(string name);
}