namespace AdventOfCode
{
    using System;
    using System.Linq;
    using AdventOfCode.Utilities.File;
    using File = AdventOfCode.Utilities.File.File;

    public class Day1 : IChallenge
    {
        public void Run()
        {
            var intArray = File.ConvertToArray("./Day 1/Input.txt", Convert.ToInt32);
            Console.WriteLine(GetNumberOfElementsGreaterThanPreviousIndex(intArray));
            Console.WriteLine(CountLargerThanSums(intArray));
        }

        private int GetNumberOfElementsGreaterThanPreviousIndex(int[] array)
        {
            var count = 0;
            for (var i = 1; i < array.Length; i++)
            {
                if (array[i].IsGreaterThan(array[i - 1])) { count++; }
            }
            return count;
        }

        private int CountLargerThanSums(int[] array)
        {
            var count = 0;
            var prevSum = 0;
            var curSum = 0;
            for (var i = 0; i < array.Length; i++)
            {
                if (!array.IsValidIndex(i + 2)) break;
                curSum = array.RangeSubset(i, 3).Sum();
                if (i != 0 && curSum.IsGreaterThan(prevSum)) count++;
                prevSum = curSum;
            }
            return count;
        }
    }
}