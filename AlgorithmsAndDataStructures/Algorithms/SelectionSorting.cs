using Algorithms.Infrastructure;

namespace Algorithms
{
    public static class SelectionSorting
    {
        public static void SelectionSort(this int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var minIndex = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                array.Swap(minIndex, i);
            }
        }
    }
}