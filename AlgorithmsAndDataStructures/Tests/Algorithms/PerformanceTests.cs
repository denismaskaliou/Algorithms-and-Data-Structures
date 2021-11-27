using Algorithms;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Algorithms
{
    public sealed class PerformanceTests
    {
        private readonly ITestOutputHelper _output;
        private readonly Task<string> _defaultTask;

        public PerformanceTests(ITestOutputHelper output)
        {
            _output = output;
            _defaultTask = Task.FromResult(new string(' ', 6) + "skipped" + new string(' ', 6));
        }

        [Fact]
        public async Task PerformanceTest()
        {
            // Arrange
            var smallArraySize = 1_000;
            var bigArraySize = 10_000_000;

            var includeDefaultSort = true;
            var includeBubbleSort = false;
            var includeInsertionSort = false;
            var includeSelectionSort = false;
            var includeHeapSort = true;
            var includeMergeSort = true;
            var includeQuickSort = true;

            // Act
            // Default sort
            var smallArrayDefaultSortTask = _defaultTask;
            var bigArrayDefaultSortTask = _defaultTask;
            if (includeDefaultSort)
            {
                smallArrayDefaultSortTask = Task.Run(() => MeasureSortAndCheck(array => Array.Sort<int>(array), smallArraySize));
                bigArrayDefaultSortTask = Task.Run(() => MeasureSortAndCheck(array => Array.Sort<int>(array), bigArraySize));
            }

            // Bubble sort
            var smallArrayBubbleSortTask = _defaultTask;
            var bigArrayBubbleSortTask = _defaultTask;
            if (includeBubbleSort)
            {
                smallArrayBubbleSortTask = Task.Run(() => MeasureSortAndCheck(array => array.BubbleSort(), smallArraySize));
                bigArrayBubbleSortTask = Task.Run(() => MeasureSortAndCheck(array => array.BubbleSort(), bigArraySize));
            }

            // Insertion sort
            var smallArrayInsertionSortTask = _defaultTask;
            var bigArrayInsertionSortTask = _defaultTask;
            if (includeInsertionSort)
            {
                smallArrayInsertionSortTask = Task.Run(() => MeasureSortAndCheck(array => array.InsertionSort(), smallArraySize));
                bigArrayInsertionSortTask = Task.Run(() => MeasureSortAndCheck(array => array.InsertionSort(), bigArraySize));
            }

            // Selection sort
            var smallArraySelectionSortTask = _defaultTask;
            var bigArraySelectionSortTask = _defaultTask;
            if (includeSelectionSort)
            {
                smallArraySelectionSortTask = Task.Run(() => MeasureSortAndCheck(array => array.SelectionSort(), smallArraySize));
                bigArraySelectionSortTask = Task.Run(() => MeasureSortAndCheck(array => array.SelectionSort(), bigArraySize));
            }

            // Heap sort
            var smallArrayHeapSortTask = _defaultTask;
            var bigArrayHeapSortTask = _defaultTask;
            if (includeHeapSort)
            {
                smallArrayHeapSortTask = Task.Run(() => MeasureSortAndCheck(array => array.HeapSort(), smallArraySize));
                bigArrayHeapSortTask = Task.Run(() => MeasureSortAndCheck(array => array.HeapSort(), bigArraySize));
            }

            // Merge sort
            var smallArrayMergeSortTask = _defaultTask;
            var bigArrayMergeSortTask = _defaultTask;
            if (includeMergeSort)
            {
                smallArrayMergeSortTask = Task.Run(() => MeasureSortAndCheck(array => array.MergeSort(0, array.Length - 1), smallArraySize));
                bigArrayMergeSortTask = Task.Run(() => MeasureSortAndCheck(array => array.MergeSort(0, array.Length - 1), bigArraySize));
            }

            // Quick sort
            var smallArrayQuickSortTask = _defaultTask;
            var bigArrayQuickSortTask = _defaultTask;
            if (includeQuickSort)
            {
                smallArrayQuickSortTask = Task.Run(() => MeasureSortAndCheck(array => array.QuickSort(0, array.Length - 1), smallArraySize));
                bigArrayQuickSortTask = Task.Run(() => MeasureSortAndCheck(array => array.QuickSort(0, array.Length - 1), bigArraySize));
            }

            await Task.WhenAll(
                smallArrayDefaultSortTask,
                bigArrayDefaultSortTask,
                smallArrayBubbleSortTask,
                bigArrayBubbleSortTask,
                smallArrayInsertionSortTask,
                bigArrayInsertionSortTask,
                smallArraySelectionSortTask,
                bigArraySelectionSortTask,
                smallArrayHeapSortTask,
                bigArrayHeapSortTask,
                smallArrayMergeSortTask,
                bigArrayMergeSortTask,
                smallArrayQuickSortTask,
                bigArrayQuickSortTask
            );

            // Assert
            _output.WriteLine($"|     Sort       |      Small array       |       Big array        |");
            _output.WriteLine($"|----------------|------------------------|------------------------|");
            _output.WriteLine($"| Default sort   |   {smallArrayDefaultSortTask.Result}  |   {bigArrayDefaultSortTask.Result}  |");
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
            _output.WriteLine($"| Merge sort     |   {smallArrayMergeSortTask.Result}  |   {bigArrayMergeSortTask.Result}  |");
            _output.WriteLine($"|----------------|------------------------|------------------------|");
            _output.WriteLine($"| Quick sort     |   {smallArrayQuickSortTask.Result}  |   {bigArrayQuickSortTask.Result}  |");
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

        private string MeasureSortAndCheck(Action<int[]> sortAction, int arraySize)
        {
            var stopWatch = new Stopwatch();
            var actualArray = new int[arraySize];

            for (var i = 0; i < actualArray.Length; i++)
            {
                actualArray[i] = new Random().Next(0, 1_000);
            }

            // Prepare array to ensure 
            var expectedArray = new int[arraySize];
            actualArray.CopyTo(expectedArray, 0);
            Array.Sort(expectedArray);

            // MeasureSort
            stopWatch.Restart();
            sortAction?.Invoke(actualArray);
            stopWatch.Stop();

            Assert.Equal(expectedArray, actualArray);

            return $"{stopWatch.Elapsed:c} ms";
        }
    }
}