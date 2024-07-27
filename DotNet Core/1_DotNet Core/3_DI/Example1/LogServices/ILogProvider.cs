namespace DotNet_Core._3_DI.Example1.LogServices; 

public interface ILogProvider {
    public void LogError(string msg);
    public void LogInfo(string msg);
}