using System.Linq;
using DataStructures;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Structures
{
    public sealed class HeapTests
    {
        private readonly Heap<int> _heap;
        private readonly ITestOutputHelper _output;

        public HeapTests(ITestOutputHelper output)
        {
            _output = output;
            _heap = new Heap<int>();
        }

        [Fact]
        public void Insert_ShouldInsertIntoRightPlace()
        {
            // Act
            _heap.Insert(4);
            _heap.Insert(5);
            _heap.Insert(3);
            _heap.Insert(2);
            _heap.Insert(0);
            _heap.Insert(8);
            _heap.Insert(6);
            _heap.Insert(1);

            // Assert
            Assert.Equal(new[] {0, 1, 4, 2, 3, 8, 6, 5}, _heap);
            PrintTree();
        }

        [Fact]
        public void Insert_ShouldRemoveItemAndNormalizeHeap()
        {
            // Arrange
            _heap.Insert(4);
            _heap.Insert(5);
            _heap.Insert(3);
            _heap.Insert(2);
            _heap.Insert(0);
            _heap.Insert(8);
            _heap.Insert(6);
            _heap.Insert(1);
            PrintTree("Before:");

            // Act
            _heap.Remove(0);

            // Assert
            Assert.Equal(new[] {1, 2, 4, 5, 3, 8, 6}, _heap);
            PrintTree("After:");
        }

        private void PrintTree(string comment = "")
        {
            _output.WriteLine(comment);
            for (var i = 1; i <= _heap.Count; i *= 2)
            {
                _output.WriteLine(string.Join(' ', _heap.Skip(i - 1).Take(i)));
            }
        }
    }
}