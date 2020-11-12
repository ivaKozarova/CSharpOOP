using MilitaryElite.Models;
using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral
    {
        public ICollection<Private> Privates { get; }
    }
}
