using GuessTheNumber.Highscore;
using GuessTheNumber.UserInterface;

namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Leaderboard scoreboard = new Leaderboard();
            GameInterface gameInterface = new GameInterface();
            while (true)
            {
                MenuChoice menuChoice = gameInterface.DisplayMenu();
                if(menuChoice == MenuChoice.Play)
                { 
                    Play(gameInterface);
                }
                if (menuChoice == MenuChoice.Leaderboard)
                {
                    gameInterface.DisplayLeaderboard(scoreboard.GetLeaderboard());
                }
                if (menuChoice == MenuChoice.Exit)
                {
                    Exit();
                    break;
                }
            }
        }
        private static void Play(GameInterface gameInterface)
        {
            Random random = new Random();
            int target = random.Next(100) + 1;
        }
        private static void Exit()
        {

        }
    }
}