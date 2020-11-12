using System;
using System.Collections.Generic;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal, ISoundProducable, IFeedable
    {
        private const string IVALID_FOOD_TYPE = "{0} does not eat {1}!";
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier {get; }
        public abstract ICollection<Type> PreferedFood { get; }

        public abstract string ProduceSound();
        public void Feed(IFood food)
        {
            if (!this.PreferedFood.Contains(food.GetType()))
            {
                throw new ArgumentException(string.Format(IVALID_FOOD_TYPE, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += food.Quantity * this.WeightMultiplier;
                this.FoodEaten += food.Quantity;
        }

    }
}
