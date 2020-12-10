using System.Linq;
using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository :Repository<ICar>
    {
       
        public CarRepository()
            :base()
        {
        }
        public override ICar GetByName(string name)
        {
            return this.Models.FirstOrDefault(m => m.Model == name);
        }
    }
}
