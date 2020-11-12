using WildFarm.Models;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string[] line)
        {
            Animal animal = null;
            var type = line[0];
            var name = line[1];
            var weight = double.Parse(line[2]);
            double wingSize;
            string livingRegion;
            string breed;

            switch (type)
            {
                case "Hen":
                    wingSize = double.Parse(line[3]);
                    animal = new Hen(name, weight, wingSize);
                    break;
                case "Owl":
                    wingSize = double.Parse(line[3]);
                    animal = new Owl(name, weight, wingSize);
                    break;
                case "Mouse":
                    livingRegion = line[3];
                    animal = new Mouse(name, weight, livingRegion);
                    break;
                case "Dog":
                    livingRegion = line[3];
                    animal = new Dog(name, weight, livingRegion);
                    break;
                case "Cat":
                    livingRegion = line[3];
                    breed = line[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                    break;
                case "Tiger":
                    livingRegion = line[3];
                    breed = line[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                    break;
            }

            return animal;
        }
    }
}
