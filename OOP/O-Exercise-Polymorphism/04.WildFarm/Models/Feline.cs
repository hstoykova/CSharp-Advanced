using System;

namespace WildFarm.Models;

public abstract class Feline : Mammal
{
    public string Breed { get; set; }

    public Feline(string name, double weight, string livingRegion, string breed, double increase) 
        : base(name, weight, livingRegion, increase)
    {
        Breed = breed;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
