using Microsoft.OpenApi.Models;
using WorkTitle.Api;
using WorkTitle.Api.Middleware;
using WorkTitle.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo {Title = "Wish list Api.Gate", Version = "v1"});
    opt.EnableAnnotations();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandlerMiddleware();

app.MapControllers();

app.Services.InitializeInfrastructureServices();

app.Run();
