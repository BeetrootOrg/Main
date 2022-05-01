using DLL.Context;
using DLL.Enums;
using MagicShop.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace DBContextTests
{
    public class UnitTest1
    {
        private readonly DbContextOptions<ArmoryDbContext> _options;

        public UnitTest1()
        {
            _options = new DbContextOptionsBuilder<ArmoryDbContext>()
           .UseInMemoryDatabase(databaseName: "ArmoryDataBase")
           .Options;
        }

        [Fact]
        public async Task AddAdrmor_Success()
        {
            // arrange
            int testId = 12345;
            string testName = "Test";
            var testEntity = new DLL.Entites.Base.Armor
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                ArmorType = ArmorType.Helmet,
                ArmorMaterialType = ArmorMaterialType.PlateArmor,
                Name = testName
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.Armor.Add(testEntity);
                context.SaveChanges();

                var result = await context.Armor.FirstOrDefaultAsync(x => x.Id == testId);
                var actualResult = testEntity;
            //assert
                Assert.Equal(testId, result?.Id);
                Assert.Equal(testName, result?.Name);
            }
        }


        //[Fact]
        //public void Test1()
        //{



        //}
    }
}
