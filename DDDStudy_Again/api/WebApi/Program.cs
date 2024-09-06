using System.Reflection;
using MediatR;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注入 MediaR 服务
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//配置 AutoMapper 映射，将当前程序集中所有继承了Profile类的文件都找到并注入到系统
builder.Services.AddAutoMapperSetup();  
//注册所有Ioc服务
builder.Services.RegistryServices();

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
