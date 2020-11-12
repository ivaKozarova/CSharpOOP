using P04.PizzaCalories.Common.Exceptions;
using P04.PizzaCalories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.PizzaCalories.Models
{
    public class Pizza : IPizza

    {
        private string name;
        
        public Pizza(string name)
        {
            this.Name = name;

            this.Toppings = new List<Topping>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if( 1 > value.Length || value.Length > 15)
                {
                    throw new InvalidOperationException(ExceptionsMessages.InvalidLengthOfPizzaNameExc);
                }
                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public ICollection<Topping> Toppings { get; }

        public int CountOfToppings => this.Toppings.Count;
        public double TotalCalories
            => this.Dough.CaloriesPerGram * this.Dough.Weight + this.Toppings.Sum(t => t.CaloriesPerGram * t.Weight);


        public void Add(Topping topping)
        {
            if(this.CountOfToppings >= 10)
            {
                throw new InvalidOperationException(ExceptionsMessages.LimitCountOfToppingsExc);
            }
            this.Toppings.Add(topping);
        }



    }
}
