namespace _8_HostedService; 

public class MyHostedService: BackgroundService {
    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        Console.WriteLine("MyHostedService启动");
        await Task.Delay(3000); //不要使用 Sleep
        var text = await File.ReadAllTextAsync("D:\\Programming\\Study\\DotNet Core\\8_HostedService\\text.txt");
        Console.WriteLine("MyHostedService文件读取完成");
        await Task.Delay(3000); //不要使用 Sleep
        Console.WriteLine(text);
    }
}