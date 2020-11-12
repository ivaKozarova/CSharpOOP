using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MAX_COUNT_OF_TOPPINGS = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;
        public Pizza ()
        {
            this.toppings = new List<Topping>();
        }
        public Pizza(string name)
            :this()
        {
            this.Name = name;    
        }

        public string Name 
        {
            get { return this.name; }
          private  set
            {
                if(string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough Dough 
        { 
            get { return this.dough; }
            set { this.dough = value; }
        }
        public int CountOfToppings => this.toppings.Count;
        public double TotalCalories => CalculateTotalCalories();

        private double CalculateTotalCalories()
        {
            double toppingsCal = this.toppings.Sum(t => t.CalculateToppingCalories());
            return toppingsCal + this.Dough.CalculateCalories();
        }

        public void AddTopping(Topping topping)
        {
            if(this.CountOfToppings == MAX_COUNT_OF_TOPPINGS)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
            
        }
        
    }
}
