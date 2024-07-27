namespace DotNet_Core._3_DI.Example3.ConfigServices; 

public interface IConfigReader {
    public string? GetValue(string name);
}