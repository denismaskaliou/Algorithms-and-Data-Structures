using Algorithms;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Algorithms
{
    public sealed class Sorting
    {
        private readonly ITestOutputHelper _output;

        public Sorting(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void InsertionSort()
        {
            // Arrange
            var array = new[] { 3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1 };

            // Act
            array.InsertionSort();

            // Assert
            Assert.Equal(new[] { 0, 1, 2, 3, 3, 4, 5, 6, 7, 8, 9 }, array);
        }

        [Fact]
        public void SelectionSort()
        {
            // Arrange
            var array = new[] { 3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1 };

            // Act
            array.SelectionSort();

            // Assert
            Assert.Equal(new[] { 0, 1, 2, 3, 3, 4, 5, 6, 7, 8, 9 }, array);
        }

        [Fact]
        public void BubbleSort()
        {
            // Arrange
            var array = new[] { 3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1 };

            // Act
            array.BubbleSort();

            // Assert
            Assert.Equal(new[] { 0, 1, 2, 3, 3, 4, 5, 6, 7, 8, 9 }, array);
        }

        [Fact]
        public void HeapSort()
        {
            // Arrange
            var array = new[] { 3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1 };

            // Act
            array.HeapSort();

            // Assert
            Assert.Equal(new[] { 0, 1, 2, 3, 3, 4, 5, 6, 7, 8, 9 }, array);
        }

        [Fact]
        public void MergeSort()
        {
            // Arrange
            var array = new[] { 3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1 };

            // Act
            array.MergeSort(0, array.Length - 1);

            // Assert
            Assert.Equal(new[] { 0, 1, 2, 3, 3, 4, 5, 6, 7, 8, 9 }, array);
        }

        [Fact]
        public void QuickSort()
        {
            // Arrange
            var array = new[] { 3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1 };

            // Act
            array.QuickSort(0, array.Length - 1);

            // Assert
            Assert.Equal(new[] { 0, 1, 2, 3, 3, 4, 5, 6, 7, 8, 9 }, array);
        }
    }
}