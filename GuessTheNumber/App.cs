using GuessTheNumber.Highscore;
using GuessTheNumber.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal class App
    {
        Leaderboard scoreboard;
        GameInterface gameInterface;
        public void Run()
        {
            scoreboard = new Leaderboard();
            gameInterface = new GameInterface();
            while (true)
            {
                GameInterface.MenuChoice menuChoice = gameInterface.DisplayMenu();
                if (menuChoice == GameInterface.MenuChoice.Play)
                {
                    Play();
                }
                if (menuChoice == GameInterface.MenuChoice.Leaderboard)
                {
                    gameInterface.DisplayLeaderboard(scoreboard.GetLeaderboard());
                }
                if (menuChoice == GameInterface.MenuChoice.Exit)
                {
                    Exit();
                    break;
                }
            }
        }
        private void Play()
        {
            Random random = new Random();
            int target = random.Next(100) + 1;
            int min = 1;
            int max = 100;
            int guess;
            var gameBoard = new GameBoard(min, max);
            gameBoard.Display();
            while (true)
            {
                guess = gameBoard.GetGuess();
                if (guess == target)
                {
                    int score = gameBoard.GetScore();
                    gameInterface.Winner(score);
                    if (scoreboard.NewRecord(score))
                    {
                        string name = gameInterface.AskForRekordName();
                        scoreboard.AddPlayer( name, score);
                    }
                    gameInterface.WaitForAnyKey();
                    break;
                }
                if (guess < target)
                {
                    min = guess;
                    gameBoard.UpdateRange(guess, max);
                }
                if (guess > target)
                {
                    max = guess;
                    gameBoard.UpdateRange(min, guess);
                }
            }
        }
        private void Exit()
        {
            scoreboard.Save();
        }
    }
}
