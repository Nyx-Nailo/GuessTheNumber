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
        public App()
        {
            scoreboard = new Leaderboard();
            gameInterface = new GameInterface();
        }
        public void Run()
        {
            
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
            gameInterface.NewGame();
            gameInterface.DisplayGameBoard();
            while (true)
            {
                if (gameInterface.GetScore() == 42) { gameInterface.GameOver(); break; }
                guess = gameInterface.GetGuess();
                if (guess == target)
                {
                    int score = gameInterface.GetScore();
                    gameInterface.Winner(score);
                    if (scoreboard.NewRecord(score))
                    {
                        string name = gameInterface.AskForRekordName();
                        scoreboard.AddPlayer(name, score);
                    }
                    else
                    {
                        gameInterface.WaitForAnyKey();
                    }
                    break;
                }
                if (guess < target)
                {
                    min = guess;
                    gameInterface.UpdateRange(guess, max);
                    gameInterface.HigherOrLower(true, guess);
                }
                if (guess > target)
                {
                    max = guess;
                    gameInterface.UpdateRange(min, guess);
                    gameInterface.HigherOrLower(false, guess);
                }
            }
        }
        private void Exit()
        {
            gameInterface.Exit();
        }
    }
}
