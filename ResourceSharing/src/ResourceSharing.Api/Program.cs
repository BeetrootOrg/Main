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

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
