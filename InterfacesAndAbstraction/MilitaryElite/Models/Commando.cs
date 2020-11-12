using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new HashSet<Mission>();
        }

        public ICollection<Mission> Missions { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine("Missions:")
                .AppendLine($"  {string.Join($"{Environment.NewLine}  ", this.Missions)}");
            return sb.ToString().TrimEnd();
        }
    }
}
