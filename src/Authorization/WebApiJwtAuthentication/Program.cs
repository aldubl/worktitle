using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Events;
using System.Text;
using WebApiJwtAuthentication.Configuration;
using WebApiJwtAuthentication.Infrastructure;
using WebApiJwtAuthentication.Models;
using WebApiJwtAuthentication.Publishers;
using WebApiJwtAuthentication.Publishers.Interfaces;
using WebApiJwtAuthentication.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
	.AddConfiguredAuthorization(builder.Configuration); 


builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddTransient<IClaimsService, ClaimsService>();
builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();
builder.Services.AddTransient<IPublisherRabbitMQ, PublisherRabbitMQ>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddMassTransit(x =>
        {            
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(builder.Configuration["RabbitMq:Host"], "/", host =>
                {
                    host.Username(builder.Configuration.GetValue("RabbitMq:Username", "guest"));
                    host.Password(builder.Configuration.GetValue("RabbitMq:Password", "guest"));
                });
                cfg.ConfigureEndpoints(context);
            });
        });   


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Services.InitializeInfrastructureServices();

app.Run();
