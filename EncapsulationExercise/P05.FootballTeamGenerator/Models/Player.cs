using System;

using P05.FootballTeamGenerator.Contacts;
using P05.FootballTeamGenerator.Common.Exceptions;

namespace P05.FootballTeamGenerator.Models
{
    public class Player : IPlayer
    {
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNameExc);

                }
                this.name = value;
            }
        }

        public Stats Stats { get; }
    }
}
