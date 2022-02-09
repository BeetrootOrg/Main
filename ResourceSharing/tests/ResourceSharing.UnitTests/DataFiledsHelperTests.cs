using ResourceSharing.Domain.Models;
using ResourceSharing.Domain.Services;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace ResourceSharing.UnitTests
{
    public class DataFiledsHelperTests
    {
        [Fact]
        public void IsSchemaValidShouldReturnTrue1()
        {
            IsSchemaValid(new DataField[]
            {
                new DataField
                {
                    Name = "blablabla",
                    Type = DataType.Int,
                    Default = "42"
                }
            }, true);
        }

        [Fact]
        public void IsSchemaValidShouldReturnTrue2()
        {
            IsSchemaValid(new DataField[]
            {
                new DataField
                {
                    Name = "blablabla",
                    Type = DataType.String,
                    Default = "something"
                },
                new DataField
                {
                    Name = "anotherName",
                    Type = DataType.Bool,
                    Default = "true"
                }
            }, true);
        }

        [Fact]
        public void IsSchemaValidShouldReturnTrue3()
        {
            IsSchemaValid(new DataField[]
            {
                new DataField
                {
                    Name = "blablabla",
                    Type = DataType.String,
                    Default = null
                },
                new DataField
                {
                    Name = "anotherName",
                    Type = DataType.Bool,
                    Default = null
                },
                new DataField
                {
                    Name = "anotherName2",
                    Type = DataType.Int,
                    Default = null
                }
            }, true);
        }

        [Fact]
        public void IsSchemaValidShouldReturnFalse1()
        {
            IsSchemaValid(new DataField[]
            {
                new DataField
                {
                    Name = "blablabla",
                    Type = DataType.String,
                    Default = null
                },
                new DataField
                {
                    Name = "blablabla",
                    Type = DataType.Bool,
                    Default = null
                },
                new DataField
                {
                    Name = "anotherName2",
                    Type = DataType.Int,
                    Default = null
                }
            }, false);
        }

        [Fact]
        public void IsSchemaValidShouldReturnFalse2()
        {
            IsSchemaValid(new DataField[]
            {
                new DataField
                {
                    Name = "anotherName2",
                    Type = DataType.Int,
                    Default = "str"
                }
            }, false);
        }

        [Fact]
        public void IsSchemaValidShouldReturnFalse3()
        {
            IsSchemaValid(new DataField[]
            {
                new DataField
                {
                    Name = "blablabla1",
                    Type = DataType.Bool,
                    Default = "42"
                }
            }, false);
        }

        private void IsSchemaValid(IEnumerable<DataField> fields, bool expectedResult)
        {
            // Arrange
            // Act
            var result = DataFiledsHelper.IsSchemaValid(fields);

            // Assert
            result.ShouldBe(expectedResult);
        }
    }
}