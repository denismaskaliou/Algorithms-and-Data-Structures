namespace Algorithms.Search
{
    public static class Binary
    {
        public static (int, int) BinarySearch(this int[] array, int target)
        {
            var leftBoarder = array.Search(target, 0, array.Length - 1, leftBorder: true);
            var rightBoarder = array.Search(target, leftBoarder, array.Length - 1);

            return (leftBoarder, rightBoarder);
        }

        private static int Search(this int[] array, int target, int leftIndex, int rightIndex, bool leftBorder = false)
        {
            while (rightIndex - leftIndex > 1)
            {
                var middle = (rightIndex + leftIndex) / 2;
                if (leftBorder)
                {
                    if (array[middle] >= target)
                        rightIndex = middle;
                    else
                        leftIndex = middle;
                }
                else
                {
                    if (array[middle] <= target)
                        leftIndex = middle;
                    else
                        rightIndex = middle;
                }
            }

            return leftBorder ? rightIndex : leftIndex;
        }
    }
}