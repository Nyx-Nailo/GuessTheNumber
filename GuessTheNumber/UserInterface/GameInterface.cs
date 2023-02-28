using GuessTheNumber.Highscore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace GuessTheNumber.UserInterface
{
    internal class GameInterface
    {
        public MenuChoice DisplayMenu()
        {
            Console.Clear();
            int[] menuPos = { Console.WindowWidth / 2, 3 };
            int menuIndent = 4;
            int menuChoice = 1;
            Console.SetCursorPosition(menuPos[0] - 2, menuPos[1]);
            Console.WriteLine("Meny!");
            while (true)
            {
                Console.SetCursorPosition(menuPos[0] - 5, menuPos[1] + 2);
                if (menuChoice == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; }
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                Console.WriteLine(" Nytt Spel ");
                Console.SetCursorPosition(menuPos[0] - 6, menuPos[1] + 3);
                if (menuChoice == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; }
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                Console.WriteLine(" Visa rekord ");
                Console.SetCursorPosition(menuPos[0] - 4, menuPos[1] + 4);
                if (menuChoice == 3) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; }
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                Console.WriteLine(" Avsluta ");
                ConsoleKey choice = Console.ReadKey(true).Key;
                if (choice == ConsoleKey.DownArrow)
                {
                    menuChoice++;
                    if (menuChoice == 4) { menuChoice = 1; }
                }
                if (choice == ConsoleKey.UpArrow)
                {
                    menuChoice--;
                    if (menuChoice == 0) { menuChoice = 3; }
                }
                if (choice == ConsoleKey.Enter)
                {
                    switch (menuChoice)
                    {
                        case 1:
                            return MenuChoice.Play;
                        case 2:
                            return MenuChoice.Leaderboard;
                        case 3:
                            return MenuChoice.Exit;
                    }
                }
            }
        }
        public enum MenuChoice
        {
            Play,
            Leaderboard,
            Exit
        }
        public void DisplayLeaderboard(List<Player> players)
        {
            Console.Clear();
            string text = "Rekordlista";
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, 5);
            Console.WriteLine(text);
            foreach (Player player in players)
            {
                text = $"{player.Name}: {player.Score}";
                Console.SetCursorPosition(Console.WindowWidth / 2 - text.Split(':')[0].Length, Console.CursorTop);
                Console.WriteLine(text);
            }
            WaitForAnyKey();
        }
        public void Winner(int score)
        {
            Console.Clear();
            string text = $"Du gissade rätt med {score} gissningar.";
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, 5);
            Console.WriteLine(text);
        }
        public string AskForRekordName()
        {
            string text = "Du har plaserat på rekordlistan.";
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
            text = "Skriv in ditt namn:";
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.Write(text + " ");
            int cursorW = Console.CursorLeft;
            int cursorH = Console.CursorTop;
            string input;
            while (true)
            {
                Console.SetCursorPosition( cursorW, cursorH);
                input = Console.ReadLine();
                text = "Vänligen skriv in ditt namn!";
                Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
                Console.WriteLine(text);
                if (input.Length > 0) { break; }
            }
            return input;
        }
        public void WaitForAnyKey()
        {
            Console.WriteLine();
            string text = "Tryck på valfri knapp för att fortsätta";
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
            Console.ReadKey(true);
        }
        public void Exit()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        //------------------------------------------GameBoard---------------------------------------------------
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
        private int[] _guessCol;
        public GameInterface()
        {
            Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            widthStart = 30;
            widthEnd = widthStart + 59;
            heightStart = 3;
            heightEnd = heightStart + 20;
            _rangePos = new int[] { widthStart + ((widthEnd - widthStart) / 2), heightStart + 3 };
            _rangePosMin = new int[] { _rangePos[0] - 1 - _rangeMin.ToString().Length, heightStart + 3 };
            _rangePosMax = new int[] { _rangePos[0] + 2, heightStart + 3 };
            _guessCol = new int[] { widthStart + 39 + 2, widthStart + 3, widthStart + 20 + 2};
        }
        public void NewGame()
        {
            _rangeMax = 100;
            _rangeMin = 1;
            _round = 0;
        }
        public void DisplayGameBoard()
        {
            Console.Clear();
            this.DrawBorder();
            string text = "Skriv in din gissing mellan";
            Console.SetCursorPosition( (Console.WindowWidth - text.Length) / 2, _rangePos[1] - 1);
            Console.Write(text);
            Console.SetCursorPosition(_rangePosMin[0], _rangePosMin[1]);
            Console.Write(_rangeMin);
            Console.SetCursorPosition(_rangePos[0], _rangePos[1]);
            Console.Write("-");
            Console.SetCursorPosition(_rangePosMax[0], _rangePosMax[1]);
            Console.Write(_rangeMax);
        }
        private void DrawBorder()
        {
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i <= widthEnd - widthStart; i++)
            {
                Console.SetCursorPosition(widthStart + i, heightStart);
                Console.WriteLine(" ");
                Console.SetCursorPosition(widthStart + i, heightStart + 5);
                Console.WriteLine(" ");
                Console.SetCursorPosition(widthStart + i, heightEnd);
                Console.WriteLine(" ");
            }
            for (int i = 0; i <= heightEnd - heightStart; i++)
            {
                Console.SetCursorPosition(widthStart, heightStart + i);
                Console.WriteLine("  ");
                Console.SetCursorPosition(widthEnd - 1, heightStart + i);
                Console.WriteLine("  ");
                if (i >= 5)
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
                Console.SetCursorPosition(_rangePosMin[0], _rangePosMin[1]);
                for (int i = 0; i < _rangeMin.ToString().Length; i++) { Console.Write(" "); }
                _rangeMin = min;
                _rangePosMin = new int[] { _rangePos[0] - 1 - _rangeMin.ToString().Length, heightStart + 3 };
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
            Console.SetCursorPosition( _guessCol[(_round + 1) % 3], _round / 3 + 9);
            Console.Write($"{_round + 1}: ");
            string guess = "";
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D0) { if(guess.Length > 0 && guess.Length < 3) { guess += "0"; Console.Write("0"); } }
                if (key == ConsoleKey.D1) { if (guess.Length < 3) { guess += "1"; Console.Write("1"); } }
                if (key == ConsoleKey.D2) { if (guess.Length < 3) { guess += "2"; Console.Write("2"); } }
                if (key == ConsoleKey.D3) { if (guess.Length < 3) { guess += "3"; Console.Write("3"); } }
                if (key == ConsoleKey.D4) { if (guess.Length < 3) { guess += "4"; Console.Write("4"); } }
                if (key == ConsoleKey.D5) { if (guess.Length < 3) { guess += "5"; Console.Write("5"); } }
                if (key == ConsoleKey.D6) { if (guess.Length < 3) { guess += "6"; Console.Write("6"); } }
                if (key == ConsoleKey.D7) { if (guess.Length < 3) { guess += "7"; Console.Write("7"); } }
                if (key == ConsoleKey.D8) { if (guess.Length < 3) { guess += "8"; Console.Write("8"); } }
                if (key == ConsoleKey.D9) { if (guess.Length < 3) { guess += "9"; Console.Write("9"); } }
                if (key == ConsoleKey.Enter)
                {
                    if (guess.Length > 0)
                    {
                        if (_rangeMin < Int32.Parse(guess) && Int32.Parse(guess) < _rangeMax)
                        {
                            _round++;
                            return Int32.Parse(guess);
                        }
                        else
                        {
                            Console.SetCursorPosition(_guessCol[(_round + 1) % 3], _round / 3 + 9);
                            Console.Write($"{_round + 1}:    ");
                            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
                            guess = "";
                        }
                    }
                }
                if (key == ConsoleKey.Backspace)
                {
                    if( guess.Length > 0) 
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        guess = guess.Remove(guess.Length - 1);
                    }
                }
            }
        }
        public int GetScore() { return _round; }
    }

}
