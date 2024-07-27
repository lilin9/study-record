namespace DotNet_Core._3_DI.Example3.ConfigServices; 

public class LayeredConfigReader: IConfigReader {
    private readonly IEnumerable<IConfigService> _services;

    public LayeredConfigReader(IEnumerable<IConfigService> services) {
        this._services = services;
    }
    
    public string? GetValue(string name) {
        string? value = null;

        foreach (var service in _services) {
            var newValue = service.GetValue(name);
            if (newValue != null) {
                value = newValue;
            }
        }

        return value;
    }
}