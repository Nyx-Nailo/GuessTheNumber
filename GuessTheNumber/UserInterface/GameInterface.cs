using GuessTheNumber.Highscore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.UserInterface
{
    internal class GameInterface
    {
        public MenuChoice DisplayMenu()
        {
            Console.Clear();
            int[] menuPos = { 58, 3 };
            int menuIndent = 4;
            Console.SetCursorPosition(menuPos[0], menuPos[1]);
            Console.WriteLine("Meny");
            Console.SetCursorPosition(menuPos[0] - menuIndent, menuPos[1]+2);
            Console.WriteLine("1. Spela");
            Console.SetCursorPosition(menuPos[0] - menuIndent, menuPos[1] + 3);
            Console.WriteLine("2. Visa rekord");
            Console.SetCursorPosition(menuPos[0] - menuIndent, menuPos[1] + 4);
            Console.WriteLine("3. Avsluta");
            while (true)
            {
                ConsoleKey choice = Console.ReadKey(true).Key;
                if (choice == ConsoleKey.D1) { return MenuChoice.Play; }
                if (choice == ConsoleKey.D2) { return MenuChoice.Leaderboard; }
                if (choice == ConsoleKey.D3) { return MenuChoice.Exit; }
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
            Console.WriteLine("Rekordlista");
            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name}: {player.Score}");
            }
            Console.WriteLine("\n\nTryck på valfri knapp för att fortsätta");
            Console.ReadKey(true);
        }
        public void Winner(int score)
        {
            Console.Clear();
            Console.WriteLine($"Du gissade rätt med {score} gissningar.");
        }
        public string AskForRekordName()
        {
            Console.WriteLine("Du har plaserat på rekordlistan.\nSkriv in ditt namn:");
            return Console.ReadLine();
        }
        public void WaitForAnyKey()
        {
            Console.ReadKey(true);
        }
    }

}
