using System;

using P05.FootballTeamGenerator.Common.Exceptions;

namespace P05.FootballTeamGenerator.Models
{
    public class Stats
    {
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;
        private const int COUNT_OF_STATS = 5;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                ValidateStat(nameof(Endurance), value);
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get { return this.sprint; }
           private set
            {
                ValidateStat(nameof(Sprint), value);
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get { return this.dribble; }
           private  set
            {
                ValidateStat(nameof(Dribble), value);
                this.dribble = value;
            }
        }
        public int Passing
        {
            get { return this.passing; }
            private set
            {
                ValidateStat(nameof(Passing), value);
                this.passing = value;
            }
        }
        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                ValidateStat(nameof(Shooting), value);
                this.shooting = value;
            }
        }
        public double OverallSkillLevel
                         => (this.Endurance + this.Sprint + this.Passing + this.Shooting + this.Dribble)
                            / (double)COUNT_OF_STATS;
        private void ValidateStat(string name, int stat)
        {
            if (MIN_STAT > stat || stat > MAX_STAT)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidStatValue,
                        name, MIN_STAT, MAX_STAT));
            }

        }
    }
}
