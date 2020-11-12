using System;

namespace PizzaCalories
{
   public class Dough
    {
        private const double MIN_WEIGHT = 1;
        private const double MAX_WEIGHT = 200;
        private const int Base_CALORIES = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;
       
        public Dough(string type, string bakingTechnique , double weight)
        {
            this.FlourType = type;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get { return this.flourType; }
           private set
            {
                if(value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough");
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if(value.ToLower() != "crispy" &&  value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough");
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight 
        {
            get { return this.weight; }
            private set
            {
                if(MIN_WEIGHT > value || value > MAX_WEIGHT )
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }
                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            var modifier = 1.0;
            switch (this.FlourType.ToLower())
            {
                case "white":
                    modifier *= 1.5;
                    break;
                case "wholegrain":
                    modifier *= 1.0;
                    break;
            }
            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
               modifier *= 0.9;
                    break;
                case "chewy":
                    modifier *= 1.1;
                    break;
                case "homemade":
                modifier *= 1.0;
                    break;
            }
            var calories = Base_CALORIES * this.Weight * modifier;
            return calories;
        }
    }
}
