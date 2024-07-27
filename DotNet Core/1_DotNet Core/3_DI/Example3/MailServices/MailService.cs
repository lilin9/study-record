using DotNet_Core._3_DI.Example3.LogServices;
using DotNet_Core._3_DI.Example3.ConfigServices;

namespace DotNet_Core._3_DI.Example3.MailServices; 

public class MailService: IMailService {
    private readonly ILogProvider _logProvider;
    // private readonly IConfigService _configService;
    private readonly IConfigReader _configService;

    public MailService(ILogProvider logProvider,
        IConfigReader configService) {
        this._configService = configService;
        this._logProvider = logProvider;
    }
    
    public void Send(string title, string to, string body) {
        _logProvider.LogInfo("准备发送邮件");

        var smtpServer = _configService.GetValue("SmtpServer");
        var username = _configService.GetValue("Username");
        var password = _configService.GetValue("Password");

        Console.WriteLine($"邮件服务器地址: {smtpServer}.{username}.{password}");
        Console.WriteLine($"发送邮件: {title}.{to}\n内容: {body}");
        _logProvider.LogInfo("邮件发送完毕");
    }
}