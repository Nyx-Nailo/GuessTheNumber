﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;


namespace GuessTheNumber.Highscore
{
    internal class Leaderboard
    {
        private List<Player> _players;
        public Leaderboard() 
        { 
            _players= new List<Player>();
            this.Load();
        }
        public void Load() 
        {
            var file = new StreamReader("leaderboard.txt");
            string? load = file.ReadLine();
            file.Close();

            if (!string.IsNullOrEmpty(load)) 
            {
                _players = JsonSerializer.Deserialize<List<Player>>(load);
            }
        }
        public void Save()
        {
            var file = new StreamWriter("leaderboard.txt");
            var save = JsonSerializer.Serialize(_players);
            file.Write(save);
            file.Close();
        }
        public bool NewRecord(int score) 
        {
            if(_players.Count < 5) { return true; }
            foreach(Player player in _players)
            {
                if(player.Score < score) { return true;}
            }
            return false;
        }
        public void AddPlayer(string name, int score)
        {
            _players.Add(new Player(name, score));
            _players = _players.OrderBy(p => p.Score).ToList();
            if (_players.Count() > 5) { _players.RemoveAt(5); }
        }
        public List<Player> GetLeaderboard() { return _players; }
    }
}