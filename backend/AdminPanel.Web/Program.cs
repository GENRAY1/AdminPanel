using AdminPanel.Application;
using AdminPanel.Infrastructure;
using AdminPanel.Web.Extensions;
using AdminPanel.Web.Middlewares;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddModules();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSwaggerService();
builder.Services.AddCustomCors();

var app = builder.Build();

app.UseCustomCors();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

app.RegisterModules();
app.Services.ApplyPendingMigrations();

app.Run();
