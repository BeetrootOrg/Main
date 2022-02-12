using Bogus;
using Moq;
using Newtonsoft.Json;
using ResourceSharing.Domain.Commands;
using ResourceSharing.Domain.Models;
using ResourceSharing.Domain.Models.Db;
using ResourceSharing.Domain.Repositories.Interfaces;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ResourceSharing.UnitTests
{
    public class CreateSchemaCommandHandlerTests
    {
        private readonly Mock<ISchemaRepository> _repositoryMock;

        private readonly Faker<SchemaDto> _schemaFaker;
        private readonly Faker<DataField> _fieldFaker;

        private readonly CreateSchemaCommandHandler _handler;

        public CreateSchemaCommandHandlerTests()
        {
            _repositoryMock = new Mock<ISchemaRepository>();

            _fieldFaker = new Faker<DataField>()
                .RuleFor(x => x.Name, x => x.Random.String())
                .RuleFor(x => x.Required, x => x.Random.Bool())
                .RuleFor(x => x.Default, x => x.Random.String())
                .RuleFor(x => x.Type, x => x.Random.Enum<DataType>());

            _schemaFaker = new Faker<SchemaDto>()
                .RuleFor(x => x.Id, x => x.Random.Int())
                .RuleFor(x => x.SchemaName, x => x.Random.String())
                .RuleFor(x => x.SchemaDefinition, x => JsonConvert.SerializeObject(_fieldFaker.GenerateBetween(1, 10)));

            _handler = new CreateSchemaCommandHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task HandleShouldReturnAlreadyExists()
        {
            // Arrange
            var schema = _schemaFaker.Generate();
            _repositoryMock.Setup(x => x.GetSchemaByName(schema.SchemaName, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(schema));

            var command = new CreateSchemaCommand
            {
                SchemaName = schema.SchemaName,
                Fields = _fieldFaker.GenerateBetween(1, 10)
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Result.ShouldBe(CreateSchemaResult.AlreadyExists);
            _repositoryMock.Verify(x => x.GetSchemaByName(schema.SchemaName, It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
