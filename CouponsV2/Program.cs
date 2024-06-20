using CouponsV2.Application.Utils.Profiles;
using Microsoft.AspNetCore;
using Pomelo.EntityFrameworkCore.MySql;
using CouponsV2.Application.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CouponsV2.Infrastructure.Data;
using CouponsV2.Application.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CouponsV2.Application.Services.Emails;
using CouponsV2.Application.Services.Repositories;
using MailKit;

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

// Configuration of the interfaces that will be used
builder.Services.AddScoped<ICouponsRepository, CouponsRepository>();
builder.Services.AddLogging();  // Añade el servicio de logging

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailRepository, EmailRepository>();


// Register AutoMapper profiles
builder.Services.AddAutoMapper(typeof(CouponsProfile));

// Configuration of controllers
builder.Services.AddControllers();

// Add SlackNotifier and ApiChecker to the DI container
// string slackWebhookUrl = "https://hooks.slack.com/services/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";
// string apiUrl = "http://localhost:5295/api/coupons/list";
// builder.Services.AddSingleton(new SlackNotifier(slackWebhookUrl));
// builder.Services.AddSingleton(new ApiChecker(apiUrl, new SlackNotifier(slackWebhookUrl)));

var app = builder.Build();

// Create an instance of SlackNotifier with the URL of the webhook
// var slackNotifier = new SlackNotifier(slackWebhookUrl);

// // Create an instance of ApiChecker with the URL of the API and the Slack notifier
// var apiChecker = new ApiChecker(apiUrl, slackNotifier);

// Check the API asynchronously
// await apiChecker.CheckApiAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
