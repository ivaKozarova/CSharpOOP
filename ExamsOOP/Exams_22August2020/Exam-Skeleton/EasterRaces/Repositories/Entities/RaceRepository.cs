using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories.Entities
{
   public class RaceRepository :Repository<IRace>
    {
        public RaceRepository()
            :base()
        {
        }
        public override IRace GetByName(string name)
        {
            return this.Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
