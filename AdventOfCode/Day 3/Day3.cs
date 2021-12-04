namespace AdventOfCode
{
    using System;
    using System.Linq;
    using AdventOfCode.Utilities.File;
    using File = AdventOfCode.Utilities.File.File;

    public class Day3 : IChallenge
    {
        private const int BINARY_LENGTH = 12;
        private int[] _diagnostic;
        private string[] _inputArray;
        private string _binary;
        private string _binaryFlipped;
        private int _gammaRate;
        private int _epsilonRate;
        private int _powerConsumption;
        private string _oxygenGeneratorRatingBinary;
        private int _oxygenGeneratorRating;
        private string _c02ScrubberRatingBinary;
        private int _c02ScrubberRating;
        private int _lifeSupportRating;

        
        public void Run()
        {
            _diagnostic = new int[BINARY_LENGTH];
            _inputArray = File.ConvertToArray("./Day 3/Input.txt", s => s);
            File.PerformActionEachLine("./Day 3/Input.txt", ConvertToDiagnostic);
            ConvertDiagnosticToBinary();
            
            _binaryFlipped = FlipBits(_binary);
            _gammaRate = Convert.ToInt32(_binary, 2);
            _epsilonRate = Convert.ToInt32(_binaryFlipped, 2);
            _powerConsumption = _gammaRate * _epsilonRate;
            _oxygenGeneratorRatingBinary = BitCriteriaMask('1');
            _c02ScrubberRatingBinary = BitCriteriaMask('0', true);
            _oxygenGeneratorRating = Convert.ToInt32(_oxygenGeneratorRatingBinary, 2);
            _c02ScrubberRating = Convert.ToInt32(_c02ScrubberRatingBinary, 2);
            _lifeSupportRating = _oxygenGeneratorRating * _c02ScrubberRating;
            
            Console.WriteLine($"Gamma Rate              | Binary: {_binary} Int: {_gammaRate}");
            Console.WriteLine($"Epsilon Rate            | Binary: {_binaryFlipped} Int: {_epsilonRate}");
            Console.WriteLine($"Power Consumption       | {_powerConsumption}");
            Console.WriteLine($"Oxygen Generator Rating | Binary: {_oxygenGeneratorRatingBinary} Int: {_oxygenGeneratorRating}");
            Console.WriteLine($"C02 Scrubber Rating     | Binary: {_c02ScrubberRatingBinary} Int: {_c02ScrubberRating}");
            Console.WriteLine($"Life Support Rating     | {_lifeSupportRating}");
        }

        private string FlipBits(string input)
        {
            return input.Aggregate(string.Empty, (current, c) => current + (c == '1' ? '0' : '1'));
        }

        private void ConvertToDiagnostic(string inputLine)
        {
            for (var i = 0; i < inputLine.Length; i++)
            {
                _diagnostic[i] += inputLine[i] == '1' ? 1 : -1;
            }
        }

        private string BitCriteriaMask(char equalsBit, bool keepFewer = false)
        {
            var tempArray = _inputArray;
            for (var i = 0; i < BINARY_LENGTH; i++)
            {
                if (tempArray.Length == 1)
                {
                    break;
                }
                
                var num1 = tempArray.Count(x => x[i] == '1');
                var num0 = tempArray.Count(x => x[i] == '0');
                var keepChar = num1 > num0 ? keepFewer ? '0' : '1' : keepFewer ? '1' : '0';
                tempArray = num1 == num0 ? tempArray.Where(x => x[i] == equalsBit).ToArray() : tempArray.Where(x => x[i] == keepChar).ToArray();
            }
            return tempArray[0];
        }
        
        private void ConvertDiagnosticToBinary()
        {
            _binary = string.Empty;
            foreach (var diagnostic in _diagnostic)
            {
                _binary += diagnostic > 0 ? '1' : '0';
            }
        }
    }
}