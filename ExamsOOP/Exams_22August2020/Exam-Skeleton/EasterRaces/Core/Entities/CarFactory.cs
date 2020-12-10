using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;

namespace EasterRaces.Core.Entities
{
    public class CarFactory
    {
        public ICar CreateCar(string type, string model, int Hp)
        {
            ICar car = null;

            if (type == "Sports")
            {
                car = new SportsCar(model, Hp);
            }

            else if (type == "Muscle")
            {
                car = new MuscleCar(model, Hp);
            }
            return car;
        }

    }
}
