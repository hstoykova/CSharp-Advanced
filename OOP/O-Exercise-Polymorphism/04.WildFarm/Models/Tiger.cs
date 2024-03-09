using System;

namespace WildFarm.Models;

public class Tiger : Feline
{
    private const double increase = 1.00;

    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed, increase)
    {
    }

    public override string AskForFood()
    {
        return "ROAR!!!";
    }

    public override bool CanEatFood(Food food)
    {
        return food is Meat;
    }
}
