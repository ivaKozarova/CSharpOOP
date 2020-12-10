using System;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
   public class SportsCar : Car
    {
        private const int Cubic_Centimeters = 3000;
        private const int MinHP = 250;
        private const int MaxHP = 450;
        private int hoursePower;
        public SportsCar(string model, int horsePower) 
            : base(model, horsePower)
        {
            this.CubicCentimeters = Cubic_Centimeters;
        }

        public override int HorsePower
        {
            get { return this.hoursePower; }
            protected set
            {
                if(value < MinHP || value > MaxHP)
                {
                    var msg = String.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(msg);
                }
                this.hoursePower = value;
            }
        }

        public override double CubicCentimeters { get; }
    }
}
