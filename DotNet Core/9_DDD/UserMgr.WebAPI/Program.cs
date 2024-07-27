using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserMgr.Domain;
using UserMgr.Infrastructure;
using UserMgr.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MvcOptions>(opt => {
    opt.Filters.Add<UnitOfWorkFilter>();
});
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<UserDomainService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISmsCodeSender, MockSmsCodeSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();