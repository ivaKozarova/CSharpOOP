using System;
using System.Collections.Generic;

namespace WildFarm.Contracts
{
    public  interface IFeedable
    {
        int FoodEaten { get; }
        double WeightMultiplier { get; }
        ICollection<Type> PreferedFood { get; }
        void Feed (IFood food);


    }
}
