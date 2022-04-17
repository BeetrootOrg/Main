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
using Spire.Doc;
using WebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;

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
            var _statementContext = new NewStatement();
            _courtFaker = new Faker<Court>()
                .RuleFor(x => x.Id, x => x.Random.Int(0))
                .RuleFor(x => x.Name, x => x.Random.String())
                .RuleFor(x => x.Adress, x => x.Random.String());
            _userFaker = new Faker<User>()
                .RuleFor(x => x.FirstName, x => x.Name.FirstName())
                .RuleFor(x => x.LastName, x => x.Name.LastName())
                .RuleFor(x => x.Patronymic, x => x.Name.FirstName())
                .RuleFor(x => x.DateOfBirth, x => x.Date.Past())
                .RuleFor(x => x.TaxNumber, x => x.Random.Long(1))
                .RuleFor(x => x.Address, x => x.Address.FullAddress())
                .RuleFor(x => x.Email, x => x.Internet.Email());
            var statementType = new[] { "divorce", "courtorder", "moneyclaim" };
            _statementKindFaker = new Faker<StatementKind>()
                .RuleFor(x => x.Id, x => x.Random.Int(0))
                .RuleFor(x => x.Type, x => x.PickRandom(statementType))
                .RuleFor(x => x.Name, x => x.Random.String());
            _statementFaker = new Faker<Statement>()
                .RuleFor(x => x.Id, x => x.Random.Int(0))
                .RuleFor(x => x.Court, x => _courtFaker.Generate())
                .RuleFor(x => x.Plaintiff, x => _userFaker.Generate())
                .RuleFor(x => x.Defendant, x => _userFaker.Generate())
                .RuleFor(x => x.DateOfCreation, x => System.DateTime.Now.Date)
                .RuleFor(x => x.StatementKind, x => _statementKindFaker.Generate())
                .RuleFor(x => x.Title, x => x.Random.String());

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
            var statementContext = new NewStatement();
            var statement = _statementFaker.Generate();

            //Act
            var result = statementContext.EditTemplateForDownloading(statement);

            //Assert
            result.ShouldContain("docx");
        }

    }
    public class UserControllerTest
    {
        private readonly Mock<IUserRepository> _userRepoMock;

        private readonly Faker<Court> _courtFaker;
        private readonly Faker<User> _userFaker;
        private readonly Faker<StatementKind> _statementKindFaker;
        private readonly Faker<Statement> _statementFaker;

        public UserControllerTest()
        {
             _userRepoMock = new Mock<IUserRepository>();
             var _statementContext = new NewStatement();
            _courtFaker = new Faker<Court>()
                .RuleFor(x => x.Id, x => x.Random.Int(0))
                .RuleFor(x => x.Name, x => x.Random.String())
                .RuleFor(x => x.Adress, x => x.Random.String());
            _userFaker = new Faker<User>()
                .RuleFor(x => x.FirstName, x => x.Name.FirstName())
                .RuleFor(x => x.LastName, x => x.Name.LastName())
                .RuleFor(x => x.Patronymic, x => x.Name.FirstName())
                .RuleFor(x => x.DateOfBirth, x => x.Date.Past())
                .RuleFor(x => x.TaxNumber, x => x.Random.Long(1))
                .RuleFor(x => x.Address, x => x.Address.FullAddress())
                .RuleFor(x => x.Email, x => x.Internet.Email());
            var statementType = new[] { "divorce", "courtorder", "moneyclaim" };
            _statementKindFaker = new Faker<StatementKind>()
                .RuleFor(x => x.Id, x => x.Random.Int(0))
                .RuleFor(x => x.Type, x => x.PickRandom(statementType))
                .RuleFor(x => x.Name, x => x.Random.String());
            _statementFaker = new Faker<Statement>()
                .RuleFor(x => x.Id, x => x.Random.Int(0))
                .RuleFor(x => x.Court, x => _courtFaker.Generate())
                .RuleFor(x => x.Plaintiff, x => _userFaker.Generate())
                .RuleFor(x => x.Defendant, x => _userFaker.Generate())
                .RuleFor(x => x.DateOfCreation, x => System.DateTime.Now.Date)
                .RuleFor(x => x.StatementKind, x => _statementKindFaker.Generate())
                .RuleFor(x => x.Title, x => x.Random.String());
        }

        [Fact]
        public void IndexShoulReturnsUsersList()
        {
            // Arrange
            var userFirst = _userFaker.Generate();
            var usersList = new List<User>
            {
            _userFaker.Generate(),
            userFirst,
            _userFaker.Generate()
            };

            _userRepoMock.Setup(x => x.GetUsersListAsync(CancellationToken.None))
                    .Returns(Task.FromResult(usersList));

            var controller = new UserController(_userRepoMock.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<User>>(viewResult.Model);
            model.Count().ShouldBe(3);
            model.ElementAt(1).ShouldBe(userFirst);
        }

        [Fact]
        public void DetailsShoulReturnUserFromList()
        {
            // Arrange
            var userTest = _userFaker.Generate();
            var usersList = new List<User>
            {
            _userFaker.Generate(),
            userTest,
            _userFaker.Generate()
            };

            _userRepoMock.Setup(x => x.GetUserAsync(userTest.Id, CancellationToken.None))
                    .Returns(Task.FromResult(userTest));

            var controller = new UserController(_userRepoMock.Object);

            // Act
            var result = controller.Details(userTest.Id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<User>(viewResult.Model);
            model.ShouldBe(userTest);
            model.ShouldBe(usersList[1]);
        }

    }
}