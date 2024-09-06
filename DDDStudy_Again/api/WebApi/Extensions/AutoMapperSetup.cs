using Application.AutoMapper;

namespace WebApi.Extensions {
    public static class AutoMapperSetup {
        public static void AddAutoMapperSetup(this IServiceCollection service) {
            if (service == null) throw new ArgumentNullException(nameof(service));

            //配置 AutoMapper 映射，将当前程序集中所有继承了Profile类的文件都找到并注入到系统
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AutoMapperConfig.RegisterMapping();
        }
    }
}
