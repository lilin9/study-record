using Domain.Core.Events;
using Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Context {
    /// <summary>
    /// 事件存储数据库上下文
    /// </summary>
    public class EventStoreSqlContext: DbContext {
        public DbSet<StoredEvent> StoredEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new StoredEventMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //获取连接字符串
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //数据库连接
            optionsBuilder.UseSqlServer(config.GetConnectionString("SqlserverConnection"));
        }
    }
}
