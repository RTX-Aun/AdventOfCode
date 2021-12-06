using System;

namespace AdventOfCode
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            RunChallenge(1, new Day1());
            RunChallenge(2, new Day2());
            RunChallenge(3, new Day3());
            RunChallenge(4, new Day4());
            RunChallenge(5, new Day5());
            RunChallenge(6, new Day6());
            Console.ReadLine();
        }

        private static void RunChallenge(int day, IChallenge challenge)
        {
            Console.WriteLine();
            Console.WriteLine("*----------*");
            Console.WriteLine($"Day {day}");
            Console.WriteLine("*----------*");
            Console.WriteLine();
            challenge.Run();
        }
    }
}