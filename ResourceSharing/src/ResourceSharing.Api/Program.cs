using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ResourceSharing.Domain;
using System.Data;
using System.Data.SqlClient;
using ResourceSharing.Api;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDomainDependencies();
builder.Services.Configure<ApiConfiguration>(builder.Configuration);
builder.Services.AddTransient<IDbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IOptionsMonitor<ApiConfiguration>>();
    return new SqlConnection(configuration.CurrentValue.DbConnectionString);
});
builder.Services.AddHealthChecks()
    .AddSqlServer(sp =>
    {
        var configuration = sp.GetRequiredService<IOptionsMonitor<ApiConfiguration>>();
        return configuration.CurrentValue.DbConnectionString;
    }, timeout: System.TimeSpan.FromSeconds(5));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.MapHealthChecks("/health");

app.MapControllers();

app.Run();
