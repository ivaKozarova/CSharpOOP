using System.Linq;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository :Repository<IDriver>
    {
        public DriverRepository()
            :base()
        {
        }
        public override IDriver GetByName(string name)
        {
            return this.Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
