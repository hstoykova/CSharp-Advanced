using System;

namespace WildFarm.Models;

public abstract class Mammal : Animal
{
    public string LivingRegion { get; set; }

    public Mammal(string name, double weight, string livingRegion, double increase) 
        : base(name, weight, 0, increase)
    {
        LivingRegion = livingRegion;
    }

    //public override string AskForFood()
    //{
    //    throw new NotImplementedException();
    //}
}
