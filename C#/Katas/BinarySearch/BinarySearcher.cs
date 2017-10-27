using System;

namespace Katas.BinarySearch
{
    public class BinarySearcher
    {
        public int Search(int[] array, int value)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            return Search(array, 0, array.Length, value);
        }

        public int Search(int[] array, int index, int length, int value)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (index < 0 || index >= array.Length) throw new ArgumentOutOfRangeException(nameof(index));
            if (length < 0 || index + length > array.Length) throw new ArgumentOutOfRangeException(nameof(length));

            int low = index;
            int high = index + length - 1;

            while (low <= high)
            {
                var i = GetMedian(low, high);
                if (array[i] == value) return i;
                if (array[i] < value) low = i + 1;
                else high = i - 1;
            }

            return 0;
        }

        internal int GetMedian(int low, int high)
        {
            return low + (high - low) / 2;
        }
    }
}
