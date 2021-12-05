namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using AdventOfCode.Utilities;

    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
    
    public struct Line
    {
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
        
        public Point Start { get; }
        public Point End { get; }
    }

    public class VentMap
    {
        private readonly Dictionary<Point, int> _pointMap = new();

        public int OverlapPoints { get; private set; }

        public void AddPoint(Point point)
        {
            if (_pointMap.ContainsKey(point))
            {
                if (_pointMap[point] == 1) OverlapPoints++;
                _pointMap[point]++;
            }
            else
            {
                _pointMap.Add(point, 1);
            }
        }
    }
    
    public class Day5 : IChallenge
    {
        private VentMap _ventMap;
        public void Run()
        {
            Console.WriteLine("Example Input - Part One\n");
            ConsumeInput("./Day 5/ExampleInput.txt", true);
            Console.WriteLine("\nExample Input - Part Two\n");
            ConsumeInput("./Day 5/ExampleInput.txt", false);
            
            Console.WriteLine("\nMy Input - Part One\n");
            ConsumeInput("./Day 5/Input.txt", true);
            Console.WriteLine("\nMy Input - Part Two\n");
            ConsumeInput("./Day 5/Input.txt", false);
        }
        
        private void ConsumeInput(string path, bool ignoreDiagonal)
        {
            var lines = File.ConvertToArray(path, ConvertAction);
            _ventMap = new VentMap();
            foreach (var line in lines)
            {
                if (ignoreDiagonal && line.Start.X != line.End.X && line.Start.Y != line.End.Y) continue;
                var points = LineUtilityMethods.GetPointsOnLine(line.Start.X, line.Start.Y, line.End.X, line.End.Y);
                foreach (var point in points)
                {
                    _ventMap.AddPoint(point);
                }
            }
            Console.WriteLine($"IgnoreDiagonal: {ignoreDiagonal} Points of Intersection: {_ventMap.OverlapPoints}");
        }

        private Line ConvertAction(string input)
        {
            input = input.Replace(" -> ", ",");
            var inputSplit = input.Split(',');
            return new Line(new Point(Convert.ToInt32(inputSplit[0]), Convert.ToInt32(inputSplit[1])), 
                new Point(Convert.ToInt32(inputSplit[2]), Convert.ToInt32(inputSplit[3])));
        }
    }
}