using System;

namespace WildFarm.Models;

public class Cat : Feline
{
    private const double increase = 0.3;
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed, increase)
    {
    }

    public override string AskForFood()
    {
        return "Meow";
    }

    public override bool CanEatFood(Food food)
    {
        return food is Vegetable || food is Meat;
    }

    
}
