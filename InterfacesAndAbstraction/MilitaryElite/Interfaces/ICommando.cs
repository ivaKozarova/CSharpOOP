using MilitaryElite.Models;
using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ICommando
    {
        public ICollection<Mission> Missions { get; }
    }
}
