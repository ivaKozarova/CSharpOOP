using System;
using System.Collections.Generic;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace

    {
        private const int MIN_LENGTH_OF_NAME = 5;
        private const int MIN_LAPS = 1;

        private string name;
        private int laps;
        private readonly List<IDriver> drivers;
        public Race()
        {
            this.drivers = new List<IDriver>();
        }

        public Race(string name, int laps) :
            this()
        {
            this.Name = name;
            this.Laps = laps;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < MIN_LENGTH_OF_NAME)
                {
                    var msg = String.Format(Utilities.Messages.ExceptionMessages.InvalidName, value, MIN_LENGTH_OF_NAME);
                    throw new ArgumentException(msg);
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get { return this.laps; }
            private set
            {
                if (value < MIN_LAPS)
                {
                    throw new ArgumentException(String.Format
                                                    (Utilities.Messages.ExceptionMessages.InvalidNumberOfLaps,
                                                         value));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)

            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.DriverInvalid);
            }
            else if (!driver.CanParticipate)
            {
                var msg = String.Format(Utilities.Messages.ExceptionMessages.DriverNotParticipate, driver.Name);
                throw new ArgumentException(msg);
            }
            else if (this.drivers.Contains(driver))
            {
                var msg = String.Format(Utilities.Messages.ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name);
                throw new ArgumentNullException(msg);
            }
            this.drivers.Add(driver);
        }
    }
}
