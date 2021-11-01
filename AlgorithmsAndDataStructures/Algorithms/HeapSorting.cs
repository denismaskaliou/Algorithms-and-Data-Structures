using System;
using Algorithms.Infrastructure;

namespace Algorithms
{
    public static class HeapSorting
    {
        public static void HeapSort<T>(this T[] array, SortOption sortOptions = SortOption.Asc) where T : IComparable<T>
        {
            // Heapify
            // for (var i = 1; i < array.Length; i++)
            // {
            //     array.SiftUp(i, sortOptions);
            // }

            for (var i = array.Length - 1; i > 0; i--)
            {
                array.SiftDown(i, array.Length - 1, sortOptions);
            }

            // SiftDown
            for (var i = array.Length - 1; i > 0; i--)
            {
                array.Swap(0, i);
                array.SiftDown(0, i, sortOptions);
            }
        }

        private static void SiftDown<T>(this T[] array, int parentIndex, int lastIndex, SortOption sortOptions) where T : IComparable<T>
        {
            var minIndex = parentIndex;

            foreach (var childIndex in new[] {parentIndex * 2 + 1, parentIndex * 2 + 2})
            {
                if (childIndex < lastIndex && array[minIndex].CompareTo(array[childIndex]) == (sortOptions == SortOption.Asc ? -1 : 1))
                {
                    minIndex = childIndex;
                }
            }

            if (minIndex == parentIndex)
                return;

            array.Swap(parentIndex, minIndex);
            array.SiftDown(minIndex, lastIndex, sortOptions);
        }

        private static void SiftUp<T>(this T[] array, int childIndex, SortOption sortOptions) where T : IComparable<T>
        {
            if (childIndex < 1)
                return;

            var parentIndex = childIndex % 2 == 0 ? (childIndex - 2) / 2 : (childIndex - 1) / 2;
            if (array[parentIndex].CompareTo(array[childIndex]) == (sortOptions == SortOption.Asc ? -1 : 1))
            {
                array.Swap(parentIndex, childIndex);
                array.SiftUp(parentIndex, sortOptions);
            }
        }
    }
}