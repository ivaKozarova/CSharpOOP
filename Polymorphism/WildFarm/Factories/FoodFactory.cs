using WildFarm.Models;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string[] line)
        {
            Food food = null;
            var type = line[0];
            var quantity = int.Parse(line[1]);
            switch(type)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
            }
            return food;
        }
    }
}
