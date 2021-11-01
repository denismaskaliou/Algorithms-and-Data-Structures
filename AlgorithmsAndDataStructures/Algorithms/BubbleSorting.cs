using Algorithms.Infrastructure;

namespace Algorithms
{
    public static class BubbleSorting
    {
        public static void BubbleSort(this int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            for (var j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                    array.Swap(j + 1, j);
            }
        }
    }
}