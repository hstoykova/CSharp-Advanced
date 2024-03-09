using System;

namespace WildFarm.Models;

public class Dog : Mammal
{
    private const double increase = 0.4;
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion, increase)
    {
    }

    public override string AskForFood()
    {
        return "Woof!";
    }

    public override bool CanEatFood(Food food)
    {
        return food is Meat;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
