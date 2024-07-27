namespace DotNet_Core._3_DI.Example3.LogServices; 

public class ConsoleLogProvider: ILogProvider {
    public void LogError(string msg) {
        Console.WriteLine($"ERROR: {msg}");
    }

    public void LogInfo(string msg) {
        Console.WriteLine($"INFO: {msg}");
    }
}