using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const double MIN_TOPPING_WEIGHT = 1;
        private const double MAX_TOPPING_WEIGHT = 50;
        private const double CALORIES = 2;

        private string name;
        private double weight;
        
        public Topping(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if(value.ToLower() != "meat"
                    && value.ToLower() != "veggies"
                    && value.ToLower() != "cheese"
                    && value.ToLower()!= "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.name = value;
            }
        }
        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if(MIN_TOPPING_WEIGHT > value  || value > MAX_TOPPING_WEIGHT)
                {
                    throw new ArgumentException($"{this.Name} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double CalculateToppingCalories()
        {
            var modifier = 0.0;
            switch(this.Name.ToLower())
            {
                case "meat":
                    modifier = 1.2;
                    break;
                case "veggies":
                    modifier = 0.8; 
                    break;
                case "cheese":
                    modifier = 1.1;
                    break;
                case "sauce":
                    modifier = 0.9;
                    break;
            }
            var calories = CALORIES *  modifier * this.Weight;
            return calories;
        }
    }
}
