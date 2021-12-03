namespace AdventOfCode.Utilities.File
{
    using System;
    using System.Collections;

    public static class CollectionOperations
    {
        public static bool IsValidIndex(this ICollection enumerable, int index)
        {
            return index < enumerable.Count;
        }
        
        public static T[] RangeSubset<T>(this T[] array, int startIndex, int length)
        {
            var subset = new T[length];
            Array.Copy(array, startIndex, subset, 0, length);
            return subset;
        }

        public static T[] Subset<T>(this T[] array, params int[] indices)
        {
            var subset = new T[indices.Length];
            for (var i = 0; i < indices.Length; i++)
            {
                subset[i] = array[indices[i]];
            }
            return subset;
        }
    }
}