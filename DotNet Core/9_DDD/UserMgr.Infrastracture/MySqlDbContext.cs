using System.Reflection;
using Microsoft.EntityFrameworkCore;
using UserMgr.Domain.Entities;

namespace UserMgr.Infrastructure;

public class MySqlDbContext(DbContextOptions<MySqlDbContext> opts) : DbContext(opts) {
    public DbSet<User> Users { get; set; }
    public DbSet<UserLoginHistory> UserLoginHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}