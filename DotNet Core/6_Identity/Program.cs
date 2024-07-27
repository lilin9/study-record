using _6_Identity.db;
using _6_Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注册自定义服务
builder.Services.AddDbContext<MyDbContext>(option => {
    option.UseMySql("Server=localhost;Port=3306;Database=db_test;Uid=root;Pwd=123abc;",
        ServerVersion.Parse("8.0.32-mysql"));
});
builder.Services.AddDataProtection();
builder.Services.AddIdentityCore<MyUsers>(option => {
    //配置 identity 框架配置
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequiredLength = 6;
    option.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    option.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
});
//和实体框架建立联系
var idBuilder = new IdentityBuilder(typeof(MyUsers), typeof(MyRoles), builder.Services);
idBuilder.AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders()
    .AddUserManager<UserManager<MyUsers>>()
    .AddRoleManager<RoleManager<MyRoles>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();