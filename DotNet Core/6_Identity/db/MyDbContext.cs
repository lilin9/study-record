using _6_Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _6_Identity.db; 

public class MyDbContext:IdentityDbContext<MyUsers, MyRoles, long> {
    public MyDbContext(DbContextOptions<MyDbContext> options): base(options) {
    }
}