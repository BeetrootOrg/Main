using Xunit;

namespace ConsoleApp.UnitTests
{
    public class LinkedListTests
    {
        private LinkedList<int> _list;

        public LinkedListTests()
        {
            _list = new LinkedList<int>();
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
    }
}