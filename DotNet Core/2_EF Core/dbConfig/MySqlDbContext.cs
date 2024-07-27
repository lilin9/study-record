using EF_Core.entity;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.dbConfig;

public class MySqlDbContext : DbContext {
    public DbSet<Cat> Cats { set; get; }
    public DbSet<Book> Books { set; get; }
    public DbSet<Person> Persons { set; get; }
    public DbSet<Article> Articles { set; get; }
    public DbSet<OrgUnit> OrgUnits { set; get; }
    public DbSet<Teacher> Teachers { set; get; }
    public DbSet<Student> Students { set; get; }
    public DbSet<House> Houses { set; get; }

    // private static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => builder.AddConsole());

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //配置数据库连接字符串
        optionsBuilder.UseMySql(
            "Server=localhost;Port=3306;Database=ef_core;Uid=root;Pwd=123abc;",
            ServerVersion.Parse("8.0.32-mysql")
        );
        //通过标准日志打印 SQL 语句到控制台
        // optionsBuilder.UseLoggerFactory(LoggerFactory);

        //通过简单日志输出 SQL 到控制台
        optionsBuilder.LogTo(msg => {
            if (!msg.Contains("DbCommand")) return;
            Console.WriteLine(msg);
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        //从当前程序集加载所有继承了 IEntityTypeConfiguration 的配置类
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}