namespace DotNet_Core._3_DI.Example3.MailServices; 

public interface IMailService {
    public void Send(string title, string to, string body);
}