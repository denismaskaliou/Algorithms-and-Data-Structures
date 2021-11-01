namespace Algorithms.Infrastructure
{
    public static class ArrayExtensions
    {
        public static void Swap<T>(this T[] array, int leftIndex, int rightIndex)
        {
            var temp = array[leftIndex];
            array[leftIndex] = array[rightIndex];
            array[rightIndex] = temp;
        }
    }
}