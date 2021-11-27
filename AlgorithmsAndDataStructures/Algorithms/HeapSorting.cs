using Algorithms.Infrastructure;
using System;

namespace Algorithms
{
    public static class HeapSorting
    {
        public static void HeapSort<T>(this T[] array) where T : IComparable<T>
        {
            var n = array.Length;

            for (var i = n / 2 - 1; i >= 0; i--)
                array.SiftDown(i, array.Length);

            for (var i = n - 1; i > 0; i--)
            {
                array.Swap(0, i);
                array.SiftDown(0, i);
            }
        }

        private static void SiftDown<T>(this T[] array, int parentIndex, int lastIndex) where T : IComparable<T>
        {
            var minIndex = parentIndex;

            foreach (var childIndex in new[] { parentIndex * 2 + 1, parentIndex * 2 + 2 })
            {
                if (childIndex < lastIndex &&
                    array[minIndex].CompareTo(array[childIndex]) == -1)
                {
                    minIndex = childIndex;
                }
            }

            if (minIndex == parentIndex)
                return;

            array.Swap(parentIndex, minIndex);
            array.SiftDown(minIndex, lastIndex);
        }

        public static void SiftUp<T>(this T[] array, int childIndex) where T : IComparable<T>
        {
            if (childIndex < 1)
                return;

            var parentIndex = childIndex % 2 == 0 ? (childIndex - 2) / 2 : (childIndex - 1) / 2;
            if (array[parentIndex].CompareTo(array[childIndex]) == -1)
            {
                array.Swap(parentIndex, childIndex);
                array.SiftUp(parentIndex);
            }
        }
    }
}