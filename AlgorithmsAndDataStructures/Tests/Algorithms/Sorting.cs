using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Algorithms;
using Algorithms.Infrastructure;
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
            var array = new[] {3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1};

            // Act
            array.InsertionSort();

            // Assert
            Assert.Equal(new[] {0, 1, 2, 3, 3, 4, 5, 6, 7, 8, 9}, array);
        }

        [Fact]
        public void SelectionSort()
        {
            // Arrange
            var array = new[] {3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1};

            // Act
            array.SelectionSort();

            // Assert
            Assert.Equal(new[] {0, 1, 2, 3, 3, 4, 5, 6, 7, 8, 9}, array);
        }

        [Fact]
        public void BubbleSort()
        {
            // Arrange
            var array = new[] {3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1};

            // Act
            array.BubbleSort();

            // Assert
            Assert.Equal(new[] {0, 1, 2, 3, 3, 4, 5, 6, 7, 8, 9}, array);
        }

        [Fact]
        public void HeapSortAsc()
        {
            // Arrange
            var array = new[] {3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1};

            // Act
            array.HeapSort(SortOption.Asc);

            // Assert
            Assert.Equal(new[] {0, 1, 2, 3, 3, 4, 5, 6, 7, 8, 9}, array);
        }

        [Fact]
        public void HeapSortDesc()
        {
            // Arrange
            var array = new[] {3, 7, 8, 6, 9, 2, 3, 4, 5, 0, 1};

            // Act
            array.HeapSort(SortOption.Desc);

            // Assert
            Assert.Equal(new[] {9, 8, 7, 6, 5, 4, 3, 3, 2, 1, 0}, array);
        }

        [Fact]
        public async Task PerformanceTest()
        {
            // Arrange
            var defaultTask = Task.FromResult(new string(' ', 6) + "skipped" + new string(' ', 6));
            var smallArraySize = 1_000;
            var bigArraySize = 100_000;

            var includeBubbleSort = false;
            var includeInsertionSort = false;
            var includeSelectionSort = true;
            var includeHeapSort = true;

            // Act
            // Bubble sort
            var smallArrayBubbleSortTask = defaultTask;
            var bigArrayBubbleSortTask = defaultTask;
            if (includeBubbleSort)
            {
                smallArrayBubbleSortTask = Task.Run(() => MeasureSort(array => array.BubbleSort(), smallArraySize));
                bigArrayBubbleSortTask = Task.Run(() => MeasureSort(array => array.BubbleSort(), bigArraySize));
            }

            // Insertion sort
            var smallArrayInsertionSortTask = defaultTask;
            var bigArrayInsertionSortTask = defaultTask;
            if (includeInsertionSort)
            {
                smallArrayInsertionSortTask = Task.Run(() => MeasureSort(array => array.InsertionSort(), smallArraySize));
                bigArrayInsertionSortTask = Task.Run(() => MeasureSort(array => array.InsertionSort(), bigArraySize));
            }

            // Selection sort
            var smallArraySelectionSortTask = defaultTask;
            var bigArraySelectionSortTask = defaultTask;
            if (includeSelectionSort)
            {
                smallArraySelectionSortTask = Task.Run(() => MeasureSort(array => array.SelectionSort(), smallArraySize));
                bigArraySelectionSortTask = Task.Run(() => MeasureSort(array => array.SelectionSort(), bigArraySize));
            }

            // Heap sort
            var smallArrayHeapSortTask = defaultTask;
            var bigArrayHeapSortTask = defaultTask;
            if (includeHeapSort)
            {
                smallArrayHeapSortTask = Task.Run(() => MeasureSort(array => array.HeapSort(), smallArraySize));
                bigArrayHeapSortTask = Task.Run(() => MeasureSort(array => array.HeapSort(), bigArraySize));
            }

            await Task.WhenAll(
                smallArrayBubbleSortTask,
                bigArrayBubbleSortTask,
                smallArrayInsertionSortTask,
                bigArrayInsertionSortTask,
                smallArraySelectionSortTask,
                bigArraySelectionSortTask,
                smallArrayHeapSortTask,
                bigArrayHeapSortTask
            );

            // Assert
            _output.WriteLine($"|     Sort       |      Small array       |       Big array        |");
            _output.WriteLine($"|----------------|------------------------|------------------------|");
            _output.WriteLine($"| Bubble sort    |   {smallArrayBubbleSortTask.Result}  |   {bigArrayBubbleSortTask.Result}  |");
            _output.WriteLine($"|----------------|------------------------|------------------------|");
            _output.WriteLine(
                $"| Insertion sort |   {smallArrayInsertionSortTask.Result}  |   {bigArrayInsertionSortTask.Result}  |");
            _output.WriteLine($"|----------------|------------------------|------------------------|");
            _output.WriteLine(
                $"| Selection sort |   {smallArraySelectionSortTask.Result}  |   {bigArraySelectionSortTask.Result}  |");
            _output.WriteLine($"|----------------|------------------------|------------------------|");
            _output.WriteLine($"| Heap sort      |   {smallArrayHeapSortTask.Result}  |   {bigArrayHeapSortTask.Result}  |");
            _output.WriteLine($"|----------------|------------------------|------------------------|");
        }

        private void PrintTree<T>(T[] array, string comment = "")
        {
            _output.WriteLine(comment);
            for (var i = 1; i <= array.Length; i *= 2)
            {
                _output.WriteLine(string.Join(' ', array.Skip(i - 1).Take(i)));
            }
        }

        private string MeasureSort(Action<int[]> sortAction, int arraySize)
        {
            var stopWatch = new Stopwatch();
            var array = new int[arraySize];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(0, 1_000);
            }

            stopWatch.Restart();
            sortAction?.Invoke(array);
            stopWatch.Stop();

            return $"{stopWatch.Elapsed:c} ms";
        }
    }
}