using System;

namespace WildFarm.Models;

public class Mouse : Mammal
{
    private const double increase = 0.1;

    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion, increase)
    {
    }

    public override string AskForFood()
    {
        return "Squeak";
    }

    public override bool CanEatFood(Food food)
    {
        return food is Vegetable || food is Fruit;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
