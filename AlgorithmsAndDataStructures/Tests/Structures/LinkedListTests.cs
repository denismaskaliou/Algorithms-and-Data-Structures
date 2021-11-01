using System.Linq;
using DataStructures;
using Xunit;

namespace Tests.Structures
{
    public sealed class LinkedListTests
    {
        private readonly LinkedList<int> _list;

        public LinkedListTests()
        {
            _list = new LinkedList<int>();
            
        }

        [Fact]
        public void Add_ShouldAddItem()
        {
            // Act
            _list.Add(4);

            // Assert
            Assert.Equal(1, _list.Count);
            Assert.Equal(4, _list.FirstOrDefault(x => x == 4));
        }

        [Fact]
        public void Remove_ShouldRemoveItem()
        {
            // Arrange
            _list.Add(4);
            _list.Add(6);

            // Act
            _list.Remove(6);

            // Assert
            Assert.Equal(1, _list.Count);
            Assert.Equal(0, _list.FirstOrDefault(x => x == 6));
        }

        [Fact]
        public void Remove_ShouldRemoveFirstItem()
        {
            // Arrange
            _list.Add(4);
            _list.Add(6);

            // Act
            _list.Remove(4);

            // Assert
            Assert.Equal(1, _list.Count);
            Assert.Equal(0, _list.FirstOrDefault(x => x == 4));
        }

        [Fact]
        public void Remove_ShouldRemoveSingleItem()
        {
            // Arrange
            _list.Add(4);

            // Act
            _list.Remove(4);

            // Assert
            Assert.Equal(0, _list.Count);
            Assert.Equal(0, _list.FirstOrDefault(x => x == 4));
        }

        [Fact]
        public void FirstOrDefault_ShouldFindItem()
        {
            // Arrange
            _list.Add(4);
            _list.Add(6);

            // Act
            var item = _list.FirstOrDefault(x => x == 6);

            // Assert
            Assert.Equal(6, item);
            Assert.Equal(2, _list.Count);
        }

        [Fact]
        public void Add_ShouldNotFindItem()
        {
            // Act
            var item = _list.FirstOrDefault(x => x == 6);

            // Assert
            Assert.Equal(default, item);
            Assert.Equal(0, _list.Count);
        }

        [Fact]
        public void GetEnumerator_ShouldReturnItems()
        {
            // Assert
            var expectedItems = new[] {1, 2, 3, 4, 5};
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(4);
            _list.Add(5);
            
            // Act
            var actualItems = _list.ToList();

            // Assert
            Assert.Equal(5, _list.Count);
            Assert.Equal(expectedItems, actualItems);
        }
    }
}