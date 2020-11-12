using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new HashSet<Repair>();
        }

        public ICollection<Repair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine("Repairs:")
                .AppendLine($"  {string.Join($"{Environment.NewLine}  ", this.Repairs)}");
            return sb.ToString().TrimEnd();
        }
    }
}
