using P04.PizzaCalories.Models;
using System;

namespace P04.PizzaCalories.Core
{
    class Engine
    {
        
        public Engine()
        {

        }

        public void Run()
        {
            var pizzaInfo = Console.ReadLine().Split();
            Pizza pizza = new Pizza(pizzaInfo[1]);
            var doughInfo = Console.ReadLine().Split();
            Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
            pizza.Dough = dough;

            string toppings; 
            while((toppings = Console.ReadLine()) != "END")
            {
                var toppingsInfo = toppings.Split();
                Topping topping = new Topping(toppingsInfo[1], double.Parse(toppingsInfo[2]));
                pizza.Add(topping);
            }
            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
        }
    }
}
