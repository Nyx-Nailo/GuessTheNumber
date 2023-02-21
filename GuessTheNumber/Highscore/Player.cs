using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Highscore
{
    internal class Player
    {
        public Player(string name, int score) 
        {
            Name = name;
            Score = score;
        }
        public string Name { get; }
        public int Score { get; }
    }
}
