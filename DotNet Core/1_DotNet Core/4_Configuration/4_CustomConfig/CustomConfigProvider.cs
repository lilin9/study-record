using System.Xml;
using Microsoft.Extensions.Configuration;

namespace DotNet_Core._4_Configuration._4_CustomConfig;

public class CustomConfigProvider : FileConfigurationProvider {
    public CustomConfigProvider(FileConfigurationSource source) : base(source) {
    }
    public override void Load(Stream stream) {
        //声明一个字典，存放映射结果，并忽略大小写
        var resultData = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        //获取配置文件中的节点
        var xmlDocument = new XmlDocument();
        xmlDocument.Load(stream);
       
        //获取节点 connectionStrings
        var connStrNodeList = xmlDocument.SelectNodes("/configuration/connectionStrings/add");
        //遍历节点数组，提取指定的值
        foreach (var xmlNode in connStrNodeList.Cast<XmlNode>()) {
            var name = xmlNode.Attributes["name"]?.Value;
            var connectionString = xmlNode.Attributes["connectionString"]?.Value;
            var providerName = xmlNode.Attributes["providerName"];

            //[conn1:{connectionString:"ashdss",providerName="def"},
            //conn2:{connectionString:"ervs",providerName="vdfcv"}]
            if (connectionString != null) resultData[$"{name}:connectionString"] = connectionString;
            if (providerName != null) resultData[$"{name}:providerName"] = providerName.Value;
        }
        
        //获取节点 appSettings
        var appSeNodeList = xmlDocument.SelectNodes("/configuration/connectionStrings/add");
        //遍历节点数组，提取指定的值
        foreach (var xmlNode in appSeNodeList.Cast<XmlNode>()) {
            var key = xmlNode.Attributes["key"].Value;
            key = key.Replace('.', ':');
            var value = xmlNode.Attributes["value"].Value;
            //扁平化映射
            resultData[key] = value;
        }
        this.Data = resultData!;
    }
}