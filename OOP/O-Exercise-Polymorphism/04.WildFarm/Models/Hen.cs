using System;
using System.ComponentModel.Design.Serialization;

namespace WildFarm.Models;

public class Hen : Bird
{
    private const double  increase = 0.35;

    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize, increase)
    {
        
    }
    public override string AskForFood()
    {
        return "Cluck";
    }

    public override bool CanEatFood(Food food)
    {
        return true;
    }

}
