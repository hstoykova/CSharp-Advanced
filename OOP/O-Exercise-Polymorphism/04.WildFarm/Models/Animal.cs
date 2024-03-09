using System;

namespace WildFarm.Models;

public abstract class Animal
{
    private double increase;

    public Animal(string name, double weight, int foodEaten, double increase)
    {
        Name = name;
        Weight = weight;
        FoodEaten = foodEaten;
        this.increase = increase;
    }

    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; set; }

    public abstract string AskForFood();
    public void Eat(Food food)
    {
        if (CanEatFood(food))
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * increase;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public abstract bool CanEatFood(Food food);

}
