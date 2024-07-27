namespace DotNet_Core._3_DI.Example3.ConfigServices;

public class IniFileConfigService : IConfigService {
    public string FilePath { get; set; }

    public string? GetValue(string name) {
        var kv = File.ReadAllLines(FilePath)
            .Select(ite => ite.Split('='))
            .Select(strs => new { Name = strs[0], Value = strs[1] })
            .SingleOrDefault(kv => kv.Name == name);

        return kv?.Value;
    }
}