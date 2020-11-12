using P04.PizzaCalories.Models;
using System.Collections.Generic;
using System.Dynamic;

namespace P04.PizzaCalories.Contracts
{
    public interface IPizza
    {
        string Name { get; }
        Dough Dough { get; }
        ICollection<Topping> Toppings { get; }


        

    }
}
