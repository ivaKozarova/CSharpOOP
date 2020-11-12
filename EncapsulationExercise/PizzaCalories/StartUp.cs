using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                var line = Console.ReadLine().Split();
                var nameOfPizza = line[1];
                Pizza pizza = new Pizza(nameOfPizza);
                Dough dough = CreateDough();
                pizza.Dough = dough;

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    Topping topping = CreateTopping(input);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);               
            }
        }

        private static Topping CreateTopping(string input)
        {
            var inputArg = input.Split();
            var type = inputArg[1];
            var weight = double.Parse(inputArg[2]);
            try
            {
                Topping topping = new Topping(type, weight);
                return topping;
            }
            catch (ArgumentException ae)
            {

                throw new ArgumentException(ae.Message);
            }
        }
        private static Dough CreateDough()
        {
            var input = Console.ReadLine().Split();
            var type = input[1];
            var baking = input[2];
            var weight = double.Parse(input[3]);
            try
            {
                Dough dough = new Dough(type, baking, weight);
                return dough;
            }

            catch (ArgumentException ae)
            {
                throw new ArgumentException(ae.Message);
            }

        }
    }
}





 