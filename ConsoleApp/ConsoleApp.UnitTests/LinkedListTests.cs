using Xunit;

namespace ConsoleApp.UnitTests
{
    public class LinkedListTests
    {
        private LinkedList<int> _list;

        public LinkedListTests()
        {
            _list= new LinkedList<int>();
        }


        [Fact]
        public void AddShouldAddElementToList()
        {
            // Arrange
            var item = 42;

            // Act
            _list.Add(item);

            // Assert
            var items = _list.GetAll();

            Assert.Single(items);
            Assert.Equal(item, items[0]);
        }

        [Fact]
        public void CountElementsShouldReturnCorrectValue()
        {
            // Arrange
            // Act
            var count = _list.Count;

            // Assert
            Assert.Equal(0, count);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(1)]
        public void AddSeveralElementsShouldUpdateList( params int[] data)
        {
            // Act
            AddItemsToList(data);

            // Arrange
            Assert.Equal(data.Length, _list.Count);

            for(var i = 0; i < data.Length; i++)
            {
                Assert.Equal(data[i], _list[i]);
            }

        }

        [Fact]
        public void RemoveShouldRemoveElementWithCorrectIndex()
        {
            // Arrange
            var data = new[] { 1, 2, 3 };
            var index = 1;
            AddItemsToList(data);

            // Act
            _list.Remove(index);

            // Assert
            Assert.Equal(data.Length - 1, _list.Count);
            Assert.Equal(data[0], _list[0]);
            Assert.Equal(data[2], _list[1]);
        }


        private void AddItemsToList(int[] data)
        {
            foreach (var item in data)
            {
                _list.Add(item);
            }
        }


    }
}