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
            Console.WriteLine("Meny");
            Console.WriteLine("1. Spela");
            Console.WriteLine("2. Visa rekord");
            Console.WriteLine("3. Avsluta");
            while (true)
            {
                ConsoleKey choice = Console.ReadKey(true).Key;
                if (choice == ConsoleKey.D1) { return MenuChoice.Play; }
                if (choice == ConsoleKey.D2) { return MenuChoice.Leaderboard; }
                if (choice == ConsoleKey.D3) { return MenuChoice.Exit; }
            }
        }
        public void DisplayLeaderboard(List<Player> players)
        {
            Console.WriteLine("Rekordlista");
            foreach(Player player in players)
            {
                Console.WriteLine($"{player.Name}: {player.Score}");
            }
            Console.WriteLine("\n\nTryck på valfri knapp för att fortsätta");
            Console.ReadKey(true);
        }
    }
    enum MenuChoice
    {
        Play,
        Leaderboard,
        Exit
    }
}
