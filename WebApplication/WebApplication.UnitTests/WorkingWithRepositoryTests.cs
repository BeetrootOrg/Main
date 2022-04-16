using Xunit;
using Moq;
using WebApplication.Services;
using Bogus;
using WebApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Shouldly;
using System.Linq;

namespace WebApplication.UnitTests
{
    public class WorkingWithRepositoryTests
    {
        private readonly Mock<ICourtRepository> _courtRepoMock;
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly Mock<INewStatement> _statementMock;

        private readonly Faker<Court> _courtFaker;
        private readonly Faker<User> _userFaker;
        private readonly Faker<StatementKind> _statementKindFaker;
        private readonly Faker<Statement> _statementFaker;

        public WorkingWithRepositoryTests()
        {
            _courtRepoMock = new Mock<ICourtRepository>();
            _userRepoMock = new Mock<IUserRepository>();
            _statementMock = new Mock<INewStatement>();
            _courtFaker = new Faker<Court>()
                .RuleFor(x => x.Id, x => x.Random.Int())
                .RuleFor(x => x.Name, x => x.Random.String())
                .RuleFor(x => x.Adress, x => x.Random.String());
            _userFaker = new Faker<User>()
                .RuleFor(x => x.FirstName, x => x.Name.FirstName())
                .RuleFor(x => x.LastName, x => x.Name.LastName())
                .RuleFor(x => x.Patronymic, x => x.Random.String())
                .RuleFor(x => x.DateOfBirth, x => x.Date.Past())
                .RuleFor(x => x.TaxNumber, x => x.Random.Long(1, 9999999999))
                .RuleFor(x => x.Address, x => x.Address.FullAddress())
                .RuleFor(x => x.Address, x => x.Internet.Email());
            _statementKindFaker = new Faker<StatementKind>()
                .RuleFor(x => x.Id, x => x.Random.Int())
                .RuleFor(x => x.Type, x => x.Random.String())
                .RuleFor(x => x.Name, x => x.Random.String());
            _statementFaker = new Faker<Statement>()
                .RuleFor(x => x.Court, x => new Faker<Court>())
                .RuleFor(x => x.StatementKind, x => new Faker<StatementKind>());


        }

        [Fact]
        public async Task GetCourtAsyncShouldReturnCourt()
        {
            //Arrange
            var courts = _courtFaker.GenerateBetween(1, 5);
            var court = courts.FirstOrDefault();
            _courtRepoMock.Setup(x => x.GetCourtAsync(court.Id, CancellationToken.None))
                .Returns(Task.FromResult(court));

            //Act
            var result = await _courtRepoMock.Object.GetCourtAsync(court.Id);

            //Assert
            result.ShouldBe(court);
        }
        [Fact]
        public async Task GetCourtsListAsyncShouldReturnCourtsList()
        {
            //Arrange
            var courts = new List<Court>
            {
                _courtFaker.Generate(),
                _courtFaker.Generate(),
                _courtFaker.Generate(),
            };
            _courtRepoMock.Setup(x => x.GetCourtsListAsync(CancellationToken.None))
                .Returns(Task.FromResult(courts));

            //Act
            var result = await _courtRepoMock.Object.GetCourtsListAsync(CancellationToken.None);

            //Assert
            result.ShouldBe(courts);
            result.Count.ShouldBe(3);
        }

        [Fact]
        public void CreateStatementShouldReturnNewStatement()
        {
            //Arrange
            var plaintiff = _userFaker.Generate();
            var defendant = _userFaker.Generate();
            var statementKind = _statementKindFaker.Generate();
            var court = _courtFaker.Generate();
            var statementContext = new NewStatement();

            //Act
            var result = statementContext.CreateStatement(plaintiff, defendant, statementKind, court);

            //Assert
            result.Plaintiff.FullName.ShouldBe(plaintiff.FullName);
            result.Defendant.FullName.ShouldBe(defendant.FullName);
            result.DateOfCreation.Date.ShouldBe(System.DateTime.Today.Date);
            result.Court.ShouldBe(court);
            result.StatementKind.ShouldBe(statementKind);

        }

        [Fact]
        public async Task GetStatemenKindAsyncShouldReturnStatementKind()
        {
            //Arrange
            var statementKind = _statementKindFaker.Generate();
            _statementMock.Setup(x => x.GetStatemenKindAsync(statementKind.Id, CancellationToken.None))
                .Returns(Task.FromResult(statementKind));

            //Act
            var result = await _statementMock.Object.GetStatemenKindAsync(statementKind.Id);

            //Assert
            result.ShouldBe(statementKind);
            result.Name.ShouldBe(statementKind.Name);
            result.Type.ShouldBe(statementKind.Type);
        }

        [Fact]
        public async Task GetAllStatementKindsAsyncShouldReturnListOfKinds()
        {
            //Arrange
            var statementKind = _statementKindFaker.Generate();
            var statementKinds = new List<StatementKind>
            {
            _statementKindFaker.Generate(),
            statementKind,
            _statementKindFaker.Generate(),
            };

            _statementMock.Setup(x => x.GetAllStatementKindsAsync(CancellationToken.None))
                .Returns(Task.FromResult(statementKinds));

            //Act
            var result = await _statementMock.Object.GetAllStatementKindsAsync();

            //Assert
            result.Count.ShouldBe(3);
            result[1].ShouldBe(statementKind);
            result[2].Name.ShouldBe(statementKinds[2].Name);
        }

        [Fact]
        public void EditTemplateForDownloadingShouldReturnFileName()
        {
            //Arrange
            var statement = _statementFaker.Generate();
            var _statementContext = new NewStatement();

            //Act
            var result =  _statementContext.EditTemplateForDownloading(statement);

            //Assert
            result.ShouldContain("docx");
        }
    }
}