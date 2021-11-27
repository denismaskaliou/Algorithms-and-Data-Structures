using Algorithms.Infrastructure;

namespace Algorithms
{
    public static class MergeSorting
    {
        public static void MergeSort(this int[] array, int leftIndex = 0, int rightIndex = 0)
        {
            if (leftIndex < rightIndex)
            {
                var middleIndex = (leftIndex + rightIndex) / 2;
                MergeSort(array, leftIndex, middleIndex);
                MergeSort(array, middleIndex + 1, rightIndex);
                Merge(array, leftIndex, middleIndex, rightIndex);
            }
        }

        private static void Merge(this int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            var buffer = new int[rightIndex - leftIndex + 1];
            var leftPointer = leftIndex;
            var rightPointer = middleIndex + 1;

            var index = 0;
            while (leftPointer <= middleIndex && rightPointer <= rightIndex)
                buffer[index++] = array[leftPointer] < array[rightPointer]
                    ? array[leftPointer++]
                    : array[rightPointer++];

            while (leftPointer <= middleIndex)
                buffer[index++] = array[leftPointer++];

            while (rightPointer <= rightIndex)
                buffer[index++] = array[rightPointer++];

            for (int b = 0, i = leftIndex; b < buffer.Length; b++, i++)
                array[i] = buffer[b];
        }
    }
}