using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
namespace EasterRaces.Models.Drivers.Entities
{
   public  class Driver : IDriver

    {
        private const int MIN_LENGTH_OF_NAME = 5;
        private string name;
       

        public Driver(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    var msg = string.Format(Utilities.Messages.ExceptionMessages.InvalidName, value, MIN_LENGTH_OF_NAME);
                    throw new ArgumentException(msg);
                }
                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddCar(ICar car)
        {
            if(car == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.CarInvalid);
            }
            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
