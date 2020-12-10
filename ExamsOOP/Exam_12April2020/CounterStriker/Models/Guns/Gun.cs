using System;

using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private const int MIN_BULLET_COUNT = 0;

        private string name;
        private int bulletsCount;
        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.name = value;
            }
        }

        public int BulletsCount
        {
            get { return this.bulletsCount; }
            set
            {
                if(value < MIN_BULLET_COUNT )
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }
                this.bulletsCount = value;
            }
        }
        public abstract int Fire();
      
    }
}
