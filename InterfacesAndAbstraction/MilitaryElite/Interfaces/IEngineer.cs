using MilitaryElite.Models;
using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer
    {
        public ICollection<Repair> Repairs { get;}
    }
}
