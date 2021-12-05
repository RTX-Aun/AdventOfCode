namespace AdventOfCode
{
    using System;
    using AdventOfCode.Utilities;

    public class Day2 : IChallenge
    {
        private (int horizPos, int depth, int aim) _position;
        public void Run()
        {
            var intArray = File.ConvertToArray("./Day 2/Input.txt", ConvertToMovement);
            SetPositionNoAim(intArray);
            Console.WriteLine($"Aim: Off Horizontal Position: {_position.horizPos} Depth: {_position.depth} Mult: {_position.horizPos*_position.depth}");
            SetPositionWithAim(intArray);
            Console.WriteLine($"Aim: On Horizontal Position: {_position.horizPos} Depth: {_position.depth} Mult: {_position.horizPos*_position.depth}");

        }

        private (Direction dir, int dist) ConvertToMovement(string inputLine)
        {
            var input = inputLine.Trim().Split(' ');
            var dir = input[0] switch
            {
                "forward" => Direction.Forward,
                "up" => Direction.Up,
                "down" => Direction.Down,
                _ => throw new ArgumentException()
            };
            return (dir, Convert.ToInt32(input[1]));
        }

        private void SetPositionNoAim((Direction dir, int dist)[] input)
        {
            _position = (0, 0, 0);
            foreach (var (dir, dist) in input)
            {
                switch (dir)
                {
                    case Direction.Forward:
                        _position.horizPos += dist;
                        break;
                    case Direction.Down:
                        _position.depth += dist;
                        break;
                    case Direction.Up: 
                        _position.depth -= dist;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
        
/*down X increases your aim by X units.
up X decreases your aim by X units.
forward X does two things:
It increases your horizontal position by X units.
It increases your depth by your aim multiplied by X.
*/
        private void SetPositionWithAim((Direction dir, int dist)[] input)
        {
            _position = (0, 0, 0);
            foreach (var (dir, dist) in input)
            {
                switch (dir)
                {
                    case Direction.Forward:
                        _position.horizPos += dist;
                        _position.depth += (_position.aim * dist);
                        break;
                    case Direction.Down:
                        _position.aim += dist;
                        break;
                    case Direction.Up: 
                        _position.aim -= dist;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}