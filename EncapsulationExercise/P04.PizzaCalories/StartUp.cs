using System;
using P04.PizzaCalories.Core;

namespace P04.PizzaCalories
{
    public  class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            try
            {
                engine.Run();
            }
            catch (Exception e )
            {

                Console.WriteLine(e.Message); 

            }

        }
    }
}
