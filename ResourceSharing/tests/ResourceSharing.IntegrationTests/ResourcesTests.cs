using Dapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ResourceSharing.Api.Models;
using Shouldly;
using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ResourceSharing.IntegrationTests
{
    public class ResourcesTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public ResourcesTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task HealthCheckShouldReturnOk()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/health");

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateSchemaShouldDoIt()
        {
            // Arrange
            var request = new CreateSchemaRequest
            {
                Fields = new Field[]
                {
                    new Field
                    {
                        Name = "column1",
                        Type = DataType.String,
                        Default = "abc",
                        Required = true
                    }
                }
            };

            var schemaName = Guid.NewGuid().ToString("N");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"api/schema/{schemaName}")
            {
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            // Act
            var response = await _client.SendAsync(httpRequestMessage);

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.Headers.Location.ShouldBe(new Uri("http://ToDo.com"));

            var dbConnection = (IDbConnection)_factory.Services.GetService(typeof(IDbConnection));
            var schema = await dbConnection.QueryAsync(
                "SELECT * FROM [dbo].[Schemas] WHERE SchemaName = @schemaName",
                new
                {
                    schemaName
                });

            schema.ShouldNotBeEmpty();

            var tables = await dbConnection.QueryAsync(@"SELECT * 
                                    FROM INFORMATION_SCHEMA.TABLES 
                                    WHERE TABLE_SCHEMA = 'dbo' 
                                        AND TABLE_NAME = @schemaName",
                                new
                                {
                                    schemaName
                                });

            tables.ShouldNotBeEmpty();
        }
    }
}
