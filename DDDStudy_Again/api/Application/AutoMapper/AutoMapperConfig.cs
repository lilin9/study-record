using AutoMapper;

namespace Application.AutoMapper {
    /// <summary>
    /// 静态的 AutoMapper 全局配置文件
    /// </summary>
    public class AutoMapperConfig {
        public static MapperConfiguration RegisterMapping() {
            //创建AutoMapperConfiguration，提供静态方法Configure，一次加载所有层中含有的Profile定义
            //MapperConfiguration实例可以静态存储在一个静态字段中，也可以存储在一个依赖注入容器中。
            //一旦创建，就不可以修改
            return new MapperConfiguration(cfg => {
                //领域模型 -> 视图模型的映射，是 读命令
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                //视图模型 -> 领域模型的映射，是 写命令
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
