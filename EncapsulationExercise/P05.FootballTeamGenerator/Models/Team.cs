using System;
using System.Linq;
using System.Collections.Generic;

using P05.FootballTeamGenerator.Contacts;
using P05.FootballTeamGenerator.Common.Exceptions;

namespace P05.FootballTeamGenerator.Models
{
   public class Team : ITeam
    {
        private string name;
        private ICollection<Player> players;
        public Team(string name)
        {
            this.Name = name;
            this.players = new HashSet<Player>();           
        }
        public string Name
        {
            get { return this.name; }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNameExc);
                }
                this.name = value;
            }
        }
       // public ICollection<Player> Players {get; }
        public int Rating
        {
            get
            {
                if (players.Any())
                {
                    return (int)Math.Round(players.Average(p => p.Stats.OverallSkillLevel));
                }
                else
                {
                    return 0;
                }
            }
        }       
        public void Add(Player player)
        {
            this.players.Add(player);
        }
        public void Remove(string name)
        {
            var current = this.players.FirstOrDefault(p => p.Name == name);
            if(current == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RemoveMissingPlayerExc, name, this.Name));
            }
            this.players.Remove(current);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }

    }
}
