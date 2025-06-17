using AdminPanel.Application;
using AdminPanel.Infrastructure;
using AdminPanel.Web.Extensions;
using AdminPanel.Web.Middaleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddModules();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.RegisterModules();
app.Run();