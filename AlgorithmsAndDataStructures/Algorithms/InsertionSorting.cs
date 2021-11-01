using Algorithms.Infrastructure;

namespace Algorithms
{
    public static class InsertionSorting
    {
        public static void InsertionSort(this int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var j = i;
                while (j > 0 && array[j - 1] > array[j])
                {
                    array.Swap(j - 1, j);
                    j--;
                }
            }
        }
    }
}