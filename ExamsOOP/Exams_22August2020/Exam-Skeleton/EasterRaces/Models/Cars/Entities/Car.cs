using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {

        private const int MIN_MODEL_LENGHT = 4;
        private string model;
        public Car(string model , int horsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_MODEL_LENGHT)
                {
                    var msg = string.Format(ExceptionMessages.InvalidModel, value, MIN_MODEL_LENGHT);
                    throw new ArgumentException(msg);
                }
                this.model = value;
            }
        }
        public abstract int HorsePower { get; protected set; }

        public abstract double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            var racePoints = this.CubicCentimeters / this.HorsePower * laps;
            return racePoints;
        }
    }
}
