namespace DotNet_Core._3_DI; 
using Microsoft.Extensions.DependencyInjection;

public class InfectDi {
    public void Use() {
        var server = new ServiceCollection();
        server.AddScoped<Controller>();
        server.AddScoped<ILog, LogImpl>();
        // server.AddScoped<IConfig, ConfigImpl>();
        server.AddScoped<IConfig, DbConfigImpl>();
        server.AddScoped<IStorage, StorageImpl>();

        using var provider = server.BuildServiceProvider();
        var rs = provider.GetRequiredService<Controller>();
        rs.Test();
    }
    
    
    class Controller {
        private readonly ILog _log;
        private readonly IStorage _storage;

        public Controller(ILog log, IStorage storage) {
            this._log = log;
            this._storage = storage;
        }

        public void Test() {
            _log.Log("开始上传");
            _storage.Save("abcdefg", "word.txt");
            _log.Log("上传结束");
        }

    }

    interface ILog {
        public void Log(string msg);
    }

    class LogImpl : ILog {
        public void Log(string msg) {
            Console.WriteLine($"日志: {msg}");
        }
    }

    interface IConfig {
        public string GetValue(string name);
    }

    // class ConfigImpl: IConfig {
    //     public string GetValue(string name) {
    //         return "hello";
    //     }
    // }

    class DbConfigImpl: IConfig {
        public string GetValue(string name) {
            Console.WriteLine("从数据库读取配置");
            return "hello db";
        }
    }

    interface IStorage {
        public void Save(string content, string name);
    }

    class StorageImpl: IStorage {
        private readonly IConfig _config;

        public StorageImpl(IConfig config) {
            this._config = config;
        }
        
        public void Save(string content, string name) {
            var server = _config.GetValue("server");
            Console.WriteLine($"向服务器 {server} 中名字为 {name} 的文件上传内容 {content}");
        }
    }
}