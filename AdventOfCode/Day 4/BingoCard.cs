namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BingoCard
    {
        private List<(int value, int xPos, int yPos)> _bingoCard;
        private readonly Action<BingoCard> _onBingo;
        private List<(int value, int xPos, int yPos)> _calledList = new List<(int value, int xPos, int yPos)>();
        private int _width;
        private int _height;
        
        public BingoCard(int width, int height, List<(int value, int xPos, int yPos)> numbers, Action<BingoCard> onBingo)
        {
            _width = width;
            _height = height;
            _bingoCard = numbers;
            _onBingo = onBingo;
        }
        
        public void NumberCalled(int bingoNumber)
        {
            for(var i = 0; i < _bingoCard.Count; i++)
            {
                if (_bingoCard[i].value != bingoNumber) continue;
                var foundNumber = _bingoCard[i];
                _calledList.Add(foundNumber);
                _bingoCard.RemoveAt(i);
                CheckIsBingo(foundNumber.xPos, foundNumber.yPos);
            }
           // return false;
        }

        private void CheckIsBingo(int xPos, int yPos)
        {
            var xMatches = 0;
            var yMatches = 0;
            foreach (var (_, x, y) in _calledList)
            {
                if (x == xPos) xMatches++;
                if (y == yPos) yMatches++;
                if (yMatches == _width || xMatches == _height) _onBingo?.Invoke(this);
            }
        }

        public int SumUncalledNumbers() => _bingoCard.Sum(bingoNumber => bingoNumber.value);
    }
}