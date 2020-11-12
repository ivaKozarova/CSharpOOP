using System;
using System.Collections.Generic;
using P04.PizzaCalories.Common.Exceptions;

namespace P04.PizzaCalories.Models
{
    public class Dough
    {
        private const int BASE_CALORIES = 2;
        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 200;
        private Dictionary<string, double> modifiersFlourType = new Dictionary<string, double>()
        {
            { "white" , 1.5 },
            { "wholegrain" , 1.0 }
        };
        private Dictionary<string, double> modifiersBakingTechnology = new Dictionary<string, double>
        {
            {"crispy" , 0.9},
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };


        private string flourType;
        private string bakingTechnique;
        private double weight;
       
        
        public Dough(string flour , string baking ,double weight)
        {
            this.FlourType = flour;
            this.BakingTechnique = baking;
            this.Weight = weight;
           
        }
        public string FlourType
        {
            get { return this.flourType; }
           private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new InvalidOperationException(ExceptionsMessages.InvalidTypeOfDough);
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
           private set
            {
                if (value.ToLower() != "crispy"
                    && value.ToLower() != "chewy"
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(ExceptionsMessages.InvalidTypeOfDough);
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight 
        {
            get { return this.weight; }
            set
            {
                if(MIN_WEIGHT > value || value > MAX_WEIGHT)
                {
                    throw new ArgumentException(string.Format(ExceptionsMessages.InvalidDoughWeight, MIN_WEIGHT, MAX_WEIGHT));
                }
                this.weight = value;
            }
        }
        public double CaloriesPerGram
        => modifiersFlourType[this.FlourType.ToLower()] * modifiersBakingTechnology[this.BakingTechnique.ToLower()]
                    * BASE_CALORIES;       
        
    }
}
