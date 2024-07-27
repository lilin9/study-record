namespace DotNet_Core._4_Configuration; 

public class Config {
    public string Name { get; set; }
    public int Age { get; set; }
    public Proxy Proxy { get; set; }
}

public class Proxy {
    public string Address { get; set; }
    public int Port { get; set; }
}