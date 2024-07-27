using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreBooks; 

public class MyDbContextDesignFactory: IDesignTimeDbContextFactory<MyDbContext> {
    //开发时运行
    public MyDbContext CreateDbContext(string[] args) {
        var builder = new DbContextOptionsBuilder<MyDbContext>();
        builder.UseMySql(
            "Server=localhost;Port=3306;Database=ef_core;Uid=root;Pwd=123abc;",
            ServerVersion.Parse("8.0.32-mysql")
        );
        return new MyDbContext(builder.Options);
    }
}