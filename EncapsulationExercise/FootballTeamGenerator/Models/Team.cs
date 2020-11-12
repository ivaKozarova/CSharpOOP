using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly ICollection<Player> players;
        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExcMsg);
                }
                this.name = value;

            }
        }
        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
                return (int)(Math.Round(this.players.Sum(p => p.OverallSkill)/this.players.Count));
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            var playerToRemove = this.players.FirstOrDefault(p => p.Name == playerName);
            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.MissingPlayerExcMsg,
                    playerName, this.Name));
            }
            this.players.Remove(playerToRemove);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
