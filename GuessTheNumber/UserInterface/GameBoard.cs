using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.UserInterface
{
    internal class GameBoard
    {
        private int _rangeMin;
        private int _rangeMax;
        private int _round;
        private int widthStart;
        private int widthEnd;
        private int heightStart;
        private int heightEnd;
        private int[] _rangePosMin;
        private int[] _rangePos;
        private int[] _rangePosMax;
        public GameBoard(int min = 1, int max = 100)
        {
            _rangeMax = max;
            _rangeMin = min;
            _round = 0;
            widthStart = 30;
            widthEnd = widthStart + 59;
            heightStart = 3;
            heightEnd = heightStart + 20;
            _rangePosMin = new int[] { 56, 5 };
            _rangePos = new int[] { widthStart + ((widthEnd - widthStart) / 2), heightStart + 2 };
            _rangePosMax = new int[] { 64, 5 };
    }
        
        public void Display()
        {
            Console.Clear();
            this.DrawBorder();
            Console.SetCursorPosition(_rangePosMin[0], _rangePosMin[1]);
            Console.Write(_rangeMin);
            Console.SetCursorPosition(_rangePos[0], _rangePos[1]);
            Console.Write("-");
            Console.SetCursorPosition(_rangePosMax[0], _rangePosMax[1]);
            Console.Write(_rangeMax);
        }
        private void DrawBorder()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i <= widthEnd - widthStart; i++)
            {
                Console.SetCursorPosition(widthStart + i, heightStart);
                Console.WriteLine(" ");
                Console.SetCursorPosition(widthStart + i, heightEnd);
                Console.WriteLine(" ");
            }
            for (int i = 0; i <= widthEnd - widthStart; i++)
            {
                Console.SetCursorPosition(widthStart + i, heightStart + 4);
                Console.WriteLine(" ");
            }
            for (int i = 0; i <= heightEnd - heightStart; i++)
            {
                Console.SetCursorPosition( widthStart, heightStart + i);
                Console.WriteLine("  ");
                Console.SetCursorPosition(widthEnd - 1, heightStart + i);
                Console.WriteLine("  ");
                if(i >= 4)
                {
                    Console.SetCursorPosition(widthStart + 20, heightStart + i);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(widthStart + 39, heightStart + i);
                    Console.WriteLine(" ");
                    
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void UpdateRange(int min, int max)
        {
            if (!(min == _rangeMin))
            {
                _rangeMin = min;
                Console.SetCursorPosition(_rangePosMin[0], _rangePosMin[1]);
                Console.WriteLine("   ");
                Console.SetCursorPosition(_rangePosMin[0], _rangePosMin[1]);
                Console.WriteLine(_rangeMin);
            }
            if (!(max == _rangeMax))
            {
                _rangeMax = max;
                Console.SetCursorPosition(_rangePosMax[0], _rangePosMax[1]);
                Console.WriteLine("   ");
                Console.SetCursorPosition(_rangePosMax[0], _rangePosMax[1]);
                Console.WriteLine(_rangeMax);
            }
        }
        public int GetGuess()
        {
            while (true)
            {
                Console.SetCursorPosition(30, _round + 4);
                Console.Write($"{_round + 1}: ");
                string input = Console.ReadLine();
                int guess;
                if (Int32.TryParse(input, out guess)) { _round++; return guess; }
            }
        }
        public int GetScore() { return _round; }
    }
}
