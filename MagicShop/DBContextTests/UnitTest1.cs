using DLL.Context;
using DLL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DBContextTests
{
    public class UnitTest1
    {
        private readonly DbContextOptions<ArmoryDbContext> _options;
        private  const string _testName = "Test";

        public UnitTest1()
        {
            _options = new DbContextOptionsBuilder<ArmoryDbContext>()
           .UseInMemoryDatabase(databaseName: "ArmoryDataBase")
           .Options;
        }

        #region Armor

        [Fact]
        public async Task AddArmor_Success()
        {
            // arrange
            int testId = 12345;
            var testEntity = new DLL.Entites.Base.Armor
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                Name = _testName,
                ArmorType = ArmorType.Helmet,
                ArmorMaterialType = ArmorMaterialType.PlateArmor
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
                Assert.Equal(_testName, result?.Name);
            }
        }

        [Fact]
        public async Task UpdateArmor_Success()
        {
            // arrange
            int testId = 12346;
            string updatedName = "Testing";
            var testEntity = new DLL.Entites.Base.Armor
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                Name = _testName,
                ArmorType = ArmorType.Helmet,
                ArmorMaterialType = ArmorMaterialType.PlateArmor
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.Armor.Add(testEntity);
                context.SaveChanges();
                testEntity.Name = updatedName;
                context.Armor.Update(testEntity);
                context.SaveChanges();

                
                var result = await context.Armor.FirstOrDefaultAsync(x => x.Id == testId);
                var actualResult = testEntity;
                //assert
                Assert.Equal(testId, result?.Id);
                Assert.Equal(updatedName, result?.Name);
            }
        }

        [Fact]
        public async Task Armor_CantAddSameId()
        {
            // arrange
            int testId = 12349;
            var testEntity = new DLL.Entites.Base.Armor
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                Name = _testName,
                ArmorType = ArmorType.Helmet,
                ArmorMaterialType = ArmorMaterialType.PlateArmor
            };
            var testEntity2 = testEntity;
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.Armor.Add(testEntity);
                context.SaveChanges();
                context.Armor.Add(testEntity2);

                //assert
                Assert.Throws<ArgumentException>(() => context.SaveChanges());
            }
        }

        [Fact]
        public async Task DeletArmor_Success()
        {
            // arrange
            int testId = 123499;
            var testEntity = new DLL.Entites.Base.Armor
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                Name = _testName,
                ArmorType = ArmorType.Helmet,
                ArmorMaterialType = ArmorMaterialType.PlateArmor
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.Armor.Add(testEntity);
                context.SaveChanges();
                context.Armor.Remove(testEntity);
                context.SaveChanges();
                var result = await context.Armor.FirstOrDefaultAsync(x => x.Id == testId);
                //assert
                Assert.Null(result);
            }
        }

        #endregion

        [Fact]
        public async Task AddAccessories_Success()
        {
            // arrange
            int testId = 12347;
            var testEntity = new DLL.Entites.Accessories
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                Name = _testName,
                ActiveEffect = "Unholy Aura",
                AccessoriesType = AccessoriesType.Ring
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.Accessories.Add(testEntity);
                context.SaveChanges();

                var result = await context.Accessories.FirstOrDefaultAsync(x => x.Id == testId);
                var actualResult = testEntity;
                //assert
                Assert.Equal(testId, result?.Id);
                Assert.Equal(_testName, result?.Name);
            }
        }
        [Fact]
        public async Task UpdateAccessories_Success()
        {
            // arrange
            int testId = 12346;
            string updatedName = "Testing";
            var testEntity = new DLL.Entites.Accessories
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                Name = _testName,
                ActiveEffect = "Unholy Aura",
                AccessoriesType = AccessoriesType.Ring
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.Accessories.Add(testEntity);
                context.SaveChanges();
                testEntity.Name = updatedName;
                context.Accessories.Update(testEntity);
                context.SaveChanges();


                var result = await context.Accessories.FirstOrDefaultAsync(x => x.Id == testId);
                var actualResult = testEntity;
                //assert
                Assert.Equal(testId, result?.Id);
                Assert.Equal(updatedName, result?.Name);
            }
        }
        [Fact]
        public async Task Accessories_CantAddSameId()
        {
            // arrange
            int testId = 12349;
            var testEntity = new DLL.Entites.Accessories
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                Name = _testName,
                ActiveEffect = "Unholy Aura",
                AccessoriesType = AccessoriesType.Ring
            };
            var testEntity2 = testEntity;
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.Accessories.Add(testEntity);
                context.SaveChanges();
                context.Accessories.Add(testEntity2);

                //assert
                Assert.Throws<ArgumentException>(() => context.SaveChanges());
            }
        }
        [Fact]
        public async Task DeletAccessories_Success()
        {
            // arrange
            int testId = 123499;
            var testEntity = new DLL.Entites.Accessories
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                Name = _testName,
                ActiveEffect = "Unholy Aura",
                AccessoriesType = AccessoriesType.Ring
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.Accessories.Add(testEntity);
                context.SaveChanges();
                context.Accessories.Remove(testEntity);
                context.SaveChanges();
                var result = await context.Accessories.FirstOrDefaultAsync(x => x.Id == testId);
                //assert
                Assert.Null(result);
            }
        }
        [Fact]
        public async Task AddMagicWeapon_Success()
        {
            // arrange
            int testId = 12348;
            var testEntity = new DLL.Entites.MagicWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                MagicWeaponType = MagicWeaponType.Wand,
                Name = _testName
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.MagicWeapon.Add(testEntity);
                context.SaveChanges();

                var result = await context.MagicWeapon.FirstOrDefaultAsync(x => x.Id == testId);
                var actualResult = testEntity;
                //assert
                Assert.Equal(testId, result?.Id);
                Assert.Equal(_testName, result?.Name);
            }
        }
        [Fact]
        public async Task UpdateMagicWeapon_Success()
        {
            // arrange
            int testId = 12346;
            string updatedName = "Testing";
            var testEntity = new DLL.Entites.MagicWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                MagicWeaponType = MagicWeaponType.Wand,
                Name = _testName
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.MagicWeapon.Add(testEntity);
                context.SaveChanges();
                testEntity.Name = updatedName;
                context.MagicWeapon.Update(testEntity);
                context.SaveChanges();


                var result = await context.MagicWeapon.FirstOrDefaultAsync(x => x.Id == testId);
                var actualResult = testEntity;
                //assert
                Assert.Equal(testId, result?.Id);
                Assert.Equal(updatedName, result?.Name);
            }
        }
        [Fact]
        public async Task MagicWeapon_CantAddSameId()
        {
            // arrange
            int testId = 12349;
            var testEntity = new DLL.Entites.MagicWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                MagicWeaponType = MagicWeaponType.Wand,
                Name = _testName
            };
            var testEntity2 = testEntity;
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.MagicWeapon.Add(testEntity);
                context.SaveChanges();
                context.MagicWeapon.Add(testEntity2);

                //assert
                Assert.Throws<ArgumentException>(() => context.SaveChanges());
            }
        }
        [Fact]
        public async Task DeletMagicWeapon_Success()
        {
            // arrange
            int testId = 123499;
            var testEntity = new DLL.Entites.MagicWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                MagicWeaponType = MagicWeaponType.Wand,
                Name = _testName
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.MagicWeapon.Add(testEntity);
                context.SaveChanges();
                context.MagicWeapon.Remove(testEntity);
                context.SaveChanges();
                var result = await context.MagicWeapon.FirstOrDefaultAsync(x => x.Id == testId);
                //assert
                Assert.Null(result);
            }
        }
        [Fact]
        public async Task AddRangeWeapon_Success()
        {
            // arrange
            int testId = 12345;
            var testEntity = new DLL.Entites.RangeWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                Name = _testName,
                RangeWeaponType = RangeWeaponType.Bow
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.RangeWeapon.Add(testEntity);
                context.SaveChanges();

                var result = await context.Armor.FirstOrDefaultAsync(x => x.Id == testId);
                var actualResult = testEntity;
                //assert
                Assert.Equal(testId, result?.Id);
                Assert.Equal(_testName, result?.Name);
            }
        }
        [Fact]
        public async Task UpdateRangeWeapon_Success()
        {
            // arrange
            int testId = 12346;
            string updatedName = "Testing";
            var testEntity = new DLL.Entites.RangeWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                RangeWeaponType = RangeWeaponType.Bow,
                Name = _testName
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.RangeWeapon.Add(testEntity);
                context.SaveChanges();
                testEntity.Name = updatedName;
                context.RangeWeapon.Update(testEntity);
                context.SaveChanges();


                var result = await context.RangeWeapon.FirstOrDefaultAsync(x => x.Id == testId);
                var actualResult = testEntity;
                //assert
                Assert.Equal(testId, result?.Id);
                Assert.Equal(updatedName, result?.Name);
            }
        }
        public async Task RangeWeapon_CantAddSameId()
        {
            // arrange
            int testId = 12349;
            var testEntity = new DLL.Entites.RangeWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                RangeWeaponType = RangeWeaponType.Bow,
                Name = _testName
            };
            var testEntity2 = testEntity;
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.RangeWeapon.Add(testEntity);
                context.SaveChanges();
                context.RangeWeapon.Add(testEntity2);

                //assert
                Assert.Throws<ArgumentException>(() => context.SaveChanges());
            }
        }
        [Fact]
        public async Task DeletRangeWeapon_Success()
        {
            // arrange
            int testId = 123499;
            var testEntity = new DLL.Entites.RangeWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                RangeWeaponType = RangeWeaponType.Bow,
                Name = _testName
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.RangeWeapon.Add(testEntity);
                context.SaveChanges();
                context.RangeWeapon.Remove(testEntity);
                context.SaveChanges();
                var result = await context.RangeWeapon.FirstOrDefaultAsync(x => x.Id == testId);
                //assert
                Assert.Null(result);
            }
        }
        [Fact]
        public async Task AddMelleWeapon_Success()
        {
            // arrange
            int testId = 12345;
            var testEntity = new DLL.Entites.MeleeWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                Name = _testName,
                MeleeWeaponType = MeleeWeaponType.Axe
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.MeleeWeapon.Add(testEntity);
                context.SaveChanges();

                var result = await context.Armor.FirstOrDefaultAsync(x => x.Id == testId);
                var actualResult = testEntity;
                //assert
                Assert.Equal(testId, result?.Id);
                Assert.Equal(_testName, result?.Name);
            }
        }
        [Fact]
        public async Task UpdateMeleeWeapon_Success()
        {
            // arrange
            int testId = 12346;
            string updatedName = "Testing";
            var testEntity = new DLL.Entites.MeleeWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                MeleeWeaponType = MeleeWeaponType.Axe,
                Name = _testName
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.MeleeWeapon.Add(testEntity);
                context.SaveChanges();
                testEntity.Name = updatedName;
                context.MeleeWeapon.Update(testEntity);
                context.SaveChanges();


                var result = await context.MeleeWeapon.FirstOrDefaultAsync(x => x.Id == testId);
                var actualResult = testEntity;
                //assert
                Assert.Equal(testId, result?.Id);
                Assert.Equal(updatedName, result?.Name);
            }
        }
        public async Task MeleeWeapon_CantAddSameId()
        {
            // arrange
            int testId = 12349;
            var testEntity = new DLL.Entites.MeleeWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                MeleeWeaponType = MeleeWeaponType.Axe,
                Name = _testName
            };
            var testEntity2 = testEntity;
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.MeleeWeapon.Add(testEntity);
                context.SaveChanges();
                context.MeleeWeapon.Add(testEntity2);

                //assert
                Assert.Throws<ArgumentException>(() => context.SaveChanges());
            }
        }
        [Fact]
        public async Task DeletMeleeWeapon_Success()
        {
            // arrange
            int testId = 123499;
            var testEntity = new DLL.Entites.MeleeWeapon
            {
                Id = testId,
                Agility = 11,
                Strength = 22,
                Speed = 11,
                MeleeWeaponType = MeleeWeaponType.Axe,
                Name = _testName
            };
            //act
            using (var context = new ArmoryDbContext(_options))
            {
                context.MeleeWeapon.Add(testEntity);
                context.SaveChanges();
                context.MeleeWeapon.Remove(testEntity);
                context.SaveChanges();
                var result = await context.MeleeWeapon.FirstOrDefaultAsync(x => x.Id == testId);
                //assert
                Assert.Null(result);
            }
        }
    }
}
