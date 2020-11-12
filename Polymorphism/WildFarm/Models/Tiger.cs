using System;
using System.Collections.Generic;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 1;

        public override ICollection<Type> PreferedFood =>
            new List<Type>() { typeof(Meat) };
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
