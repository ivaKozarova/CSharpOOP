using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities

{
   public  class MuscleCar : Car
    {
        private const int Cubic_Centimeters = 5000;
        private const int MinHP = 400;
        private const int MaxHP = 600;

        private int horsePower;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower)
        {
            this.CubicCentimeters = Cubic_Centimeters;
        }

        public override int HorsePower
        {
            get { return this.horsePower; }

            protected set
            {
                if(value > MaxHP || value < MinHP)
                {
                    var msg = string.Format(ExceptionMessages.InvalidHorsePower,value );
                    throw new ArgumentException(msg);
                }
                this.horsePower = value;
            }
        }
        public override double CubicCentimeters { get; }
        
    }
}
