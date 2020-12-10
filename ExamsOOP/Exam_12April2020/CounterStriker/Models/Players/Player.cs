using System;
using System.Text;

using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private const int MIN_HEALTH = 0;
        private const int MIN_ARMOR = 0;

        private string username;
        private int health;
        private int armor;
        private IGun gun;
        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.username = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if(value < MIN_HEALTH)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get { return this.armor; }
            set
            {
                if(value < MIN_ARMOR )
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }

        public IGun Gun
        {
            get { return this.gun; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.gun = value;
            }
        }

        public bool IsAlive
        {
            get => this.Health > MIN_HEALTH;
           
        }

        public void TakeDamage(int points)
        {            
            if(this.Armor - points < MIN_ARMOR)
            {
                points -= this.Armor;
                this.Armor = 0;
                 
                if(this.Health - points < 0)
                {                   
                    this.Health = 0;
                }
                else
                {
                    this.Health -= points;
                }
            }
            else
            {
                this.Armor -= points;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{this.GetType().Name}: {this.Username}")
                .AppendLine($"--Health: {this.Health}")
                .AppendLine($"--Armor: {this.Armor}")
                .AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}
