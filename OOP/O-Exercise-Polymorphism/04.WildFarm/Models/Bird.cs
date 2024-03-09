using System;

namespace WildFarm.Models;

public abstract class Bird : Animal
{
    public double WingSize { get; set; }

    public Bird(string name, double weight, double wingSize, double increase) 
        : base(name, weight, 0, increase)
    {
        WingSize = wingSize;
    }

    //public override string AskForFood()
    //{
    //    return $"Need food";
    //}

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}
