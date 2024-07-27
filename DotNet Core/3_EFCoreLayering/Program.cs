using EFCoreBooks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//连接数据库配置
builder.Services.AddDbContext<MyDbContext>(options => {
    options.UseMySql(
        "Server=localhost;Port=3306;Database=ef_core;Uid=root;Pwd=123abc;",
        ServerVersion.Parse("8.0.32-mysql")
    );
});

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