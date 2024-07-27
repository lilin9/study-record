namespace DotNet_Core._4_Configuration._4_CustomConfig; 

public class WebConfig {
    public ConnectStr Conn1 { get; set; }
    public ConnectStr Conn2 { get; set; }
    public Config Config { get; set; }
}

public class ConnectStr {
    public string ConnectionString { get; set; }
    public string ProviderName { get; set; }
}