namespace WebApi.Extensions {
    public static class CorsServiceExtensions {
        private static readonly string PolicyName = "MCodeCors";

        /// <summary>
        /// 配置跨域问题
        /// </summary>
        /// <param name="services"></param>
        public static void AddCodeCors(this IServiceCollection services) {
            if (services == null) {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddCors(opt => {
                opt.AddPolicy(PolicyName, policy => {
                    policy.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });
        }

        /// <summary>
        /// 使用跨域
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static void UseCodeCors(this IApplicationBuilder app) {
            app.UseCors(PolicyName);
        }
    }
}
