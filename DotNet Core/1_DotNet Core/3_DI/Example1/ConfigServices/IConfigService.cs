namespace DotNet_Core._3_DI.Example1.ConfigServices; 

public interface IConfigService {
    public string? GetValue(string name);
}