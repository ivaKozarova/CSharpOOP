using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LeutenantGeneral : Private, ILieutenantGeneral
    {
        public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new HashSet<Private>();
        }

        public ICollection<Private> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine("Privates:")
                .AppendLine($"  {string.Join($"{Environment.NewLine}  ", this.Privates)}");
            return sb.ToString().TrimEnd();
        }

    }
}
