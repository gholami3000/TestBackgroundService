using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestBackgroundService.Models;
using TestBackgroundService.Notifications;
using TestBackgroundService.Service;

var builder = WebApplication.CreateBuilder(args);

var configurations = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();

// Add services to the container.
builder.Services.AddDbContext<MyAppContext>(opt =>
             opt.UseSqlServer(configurations.GetConnectionString("App")));


builder.Services.AddTransient<RequestService>();
builder.Services.AddTransient<UpdateService>();

//builder.Services.AddScoped<BackGroundService1>();
builder.Services.AddMediatR(typeof(Program).Assembly);

//builder.Services.AddHostedService<BackGroundService1>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
