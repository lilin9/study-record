using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace TodoList_Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            AddClientServices(builder.Services);

            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));

            await builder.Build().RunAsync();

            //组件本地化
            builder.Services.AddInteractiveStringLocalizer();
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });
        }

        public static void AddClientServices(IServiceCollection services)
        {
            services.AddAntDesign();
        }
    }
}
