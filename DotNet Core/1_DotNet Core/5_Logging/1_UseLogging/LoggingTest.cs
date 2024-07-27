using Microsoft.Extensions.Logging;

namespace DotNet_Core._5_Logging._1_UseLogging;

public class LoggingTest {
    private readonly ILogger<LoggingTest> _logger;

    public LoggingTest(ILogger<LoggingTest> logger) {
        _logger = logger;
    }

    public void Test() {
        _logger.LogDebug("开始执行数据库同步");
        _logger.LogDebug("连接数据库成功");
        _logger.LogWarning("查找数据库失败，重试第一次");
        _logger.LogWarning("查找数据库失败，重试第二次");
        _logger.LogError("查找数据库最终失败");

        //还可以记录异常消息
        try {
            File.ReadAllText("A://Text.txt");
            _logger.LogDebug("读取文件成功");
        } catch (Exception e) {
            _logger.LogError(e, "读取文件失败");
        }
    }
}