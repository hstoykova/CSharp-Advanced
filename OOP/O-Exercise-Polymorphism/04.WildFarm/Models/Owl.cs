using System;

namespace WildFarm.Models;

public class Owl : Bird
{
    private const double increase = 0.25;

    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize, increase)
    {
    }

    public override string AskForFood()
    {
        return "Hoot Hoot";
    }

    public override bool CanEatFood(Food food)
    {
        return food is Meat;
    }
}
