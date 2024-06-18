using CouponsV2.Application.Utils.Profiles;
using Microsoft.AspNetCore;
using Pomelo.EntityFrameworkCore.MySql;
using  CouponsV2.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using CouponsV2.Infrastructure.Data;
using CouponsV2.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BaseContext>(Options =>
        Options.UseMySql(
            builder.Configuration.GetConnectionString("CouponsV2Connection"),
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
        ));

//Configuration of the interfaces that will be used
builder.Services.AddScoped<ICouponsRepository, CouponsRepository>();

builder.Services.AddControllers();


//Register AutoMapper profiles
builder.Services.AddAutoMapper(typeof(CouponsProfile));

//Configuration of controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.MapControllers();
app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
