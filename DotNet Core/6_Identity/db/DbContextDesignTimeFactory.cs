using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace _6_Identity.db; 

public class DbContextDesignTimeFactory:IDesignTimeDbContextFactory<MyDbContext> {
    public MyDbContext CreateDbContext(string[] args) {
        var builder = new DbContextOptionsBuilder<MyDbContext>();
        builder.UseMySql("Server=localhost;Port=3306;Database=db_test;Uid=root;Pwd=123abc;",
            ServerVersion.Parse("8.0.32-mysql"));
        return new MyDbContext(builder.Options);
    }
}