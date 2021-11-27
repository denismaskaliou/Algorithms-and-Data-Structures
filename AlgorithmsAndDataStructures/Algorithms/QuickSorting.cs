using Algorithms.Infrastructure;
using System;

namespace Algorithms
{
    public static class QuickSorting
    {
        private static Random Random = new Random();

        public static void QuickSort(this int[] array, int leftIndex = 0, int rightIndex = 0)
        {
            if (leftIndex < rightIndex)
            {
                var pivot = Partition(array, leftIndex, rightIndex);
                QuickSort(array, leftIndex, pivot - 1);
                QuickSort(array, pivot + 1, rightIndex);
            }
        }

        private static int Partition(this int[] array, int leftIndex, int rightIndex)
        {
            var leftPartIndex = leftIndex;

            for (var i = leftIndex; i < rightIndex; i++)
                if (array[i] <= array[rightIndex])
                    array.Swap(leftPartIndex++, i);

            array.Swap(leftPartIndex, rightIndex);

            return leftPartIndex;
        }
    }
}
