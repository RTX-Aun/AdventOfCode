namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day4 : IChallenge
    {
        private const int CARD_WIDTH = 5;
        private const int CARD_HEIGHT = 5;
        private int[] _numbersCalled;
        private int _currentNumber;
        private readonly List<BingoCard> _bingoCards = new();

        public void Run()
        {
            ConsumeInput("./Day 4/Input.txt");
            PlayBingo();
        }
        
        private void ConsumeInput(string path)
        {
            var lines = System.IO.File.ReadAllLines(path);
            SetNumbersCalled(lines);
            AddBingoCards(lines);
        }

        private void AddBingoCards(IList<string> lines)
        {
            for (var i = 2; i < lines.Count; i += (CARD_HEIGHT + 1))
            {
                var bingoCardNumbers = new List<(int value, int xPos, int yPos)>();
                var cardRows = new List<string[]>();
                for (var j = i; j < i + CARD_HEIGHT; j++)
                {
                    lines[j] = Regex.Replace(lines[j], @"\s+", " ").Trim();
                    cardRows.Add(lines[j].Split(' '));
                }
                for (var y = 0; y < CARD_HEIGHT; y++)
                {
                    for (var x = 0; x < CARD_WIDTH; x++) { bingoCardNumbers.Add((Convert.ToInt32(cardRows[y][x].Trim()), x, y)); }
                }
                _bingoCards.Add(new BingoCard(CARD_WIDTH, CARD_HEIGHT, bingoCardNumbers, OnBingoCalled));
            }
        }

        private void PlayBingo()
        {
            while (_bingoCards.Count > 0)
            {
                foreach (var numberCalled in _numbersCalled)
                {
                    _currentNumber = numberCalled;
                    CallBingoNumber(numberCalled);
                }
            }
        }

        private void SetNumbersCalled(IReadOnlyList<string> lines)
        {
            var numbersCalled = lines[0].Split(',');
            _numbersCalled = new int[numbersCalled.Length];
            for (var i = 0; i < numbersCalled.Length; i++) { _numbersCalled[i] = Convert.ToInt32(numbersCalled[i]); }
        }

        private void CallBingoNumber(int numberCalled)
        {
            foreach (var bingoCard in _bingoCards.ToList()) bingoCard.NumberCalled(numberCalled);
        }

        private void OnBingoCalled(BingoCard bingoCard)
        {
            Console.WriteLine($"Bingo! Current Number: {_currentNumber} Sum Uncalled: {bingoCard.SumUncalledNumbers()} Score: {_currentNumber * bingoCard.SumUncalledNumbers()}");
            _bingoCards.Remove(bingoCard);
        }
    }
}