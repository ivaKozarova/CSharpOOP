using System;
using System.Collections.Generic;
using P04.PizzaCalories.Common.Exceptions;

namespace P04.PizzaCalories.Models
{
    public class Topping
    {
        private const double BASE_CALORIES = 2;
        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 50;

        Dictionary<string, double> modifiersTopping = new Dictionary<string, double>
        {
            {"meat",1.2},
            {"veggies" ,0.8},
            {"cheese"  ,1.1},
            {"sauce", 0.9 }
        };

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
            set
            {
                if(value.ToLower() != "meat" && value.ToLower()!= "veggies"
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(string.Format(ExceptionsMessages.InvalidToppingExc, value));
                }
                this.name = value;
            }
        }
        public double Weight 
        {
            get { return this.weight; }
            set
            {
                if(MIN_WEIGHT > value || value > MAX_WEIGHT)
                {
                    throw new ArgumentException(string.Format(ExceptionsMessages.InvalidToppingWeightExc,
                        this.Name, MIN_WEIGHT, MAX_WEIGHT));
                }
                this.weight = value;
            }
        }

        public double CaloriesPerGram =>
            modifiersTopping[this.Name.ToLower()] * BASE_CALORIES;
    }
}
