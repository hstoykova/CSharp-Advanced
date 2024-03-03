using System;

namespace FoodShortage;

public class Rebel : Person, IBuyer
{
    public Rebel(string name, int age, string group) 
        : base(name, age)
    {
        Group = group;
        Food = 0;
    }
    public string Group { get; set; }
    public int Food { get; set; }

    public void BuyFood()
    {
        Food += 5;
    }
}
