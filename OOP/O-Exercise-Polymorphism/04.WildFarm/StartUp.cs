/*
Cat Sammy 1.1 Home Persian
Vegetable 4
End

 */

using WildFarm.Models;

namespace WildFarm;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        string animal;

        while ((animal = Console.ReadLine()) != "End")
        {
            string[] animalInformation = animal.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] animalFood = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string animalType = animalInformation[0];

            Animal animalInstance = CreateAnimal(animalType, animalInformation.Skip(1).ToList());

            Console.WriteLine(animalInstance.AskForFood());
            string foodType = animalFood[0];

            Food food = CreateFood(foodType, int.Parse(animalFood[1]));
            animalInstance.Eat(food);
            animals.Add(animalInstance);

        }

        foreach (var animal1 in animals)
        {
            Console.WriteLine(animal1);
        }
    }

    public static Food CreateFood(string foodType, int quantity)
    {
        switch (foodType)
        {
            case "Vegetable":
                return new Vegetable(quantity);
            case "Meat":
                return new Meat(quantity);
            case "Fruit":
                return new Fruit(quantity);
            case "Seeds":
                return new Seeds(quantity);
            default: throw new ArgumentException();
        }
    }

    public static Animal CreateAnimal(string animalType, List<string> info)
    {
        switch (animalType)
        {
            case "Cat":
                return new Cat(info[0], double.Parse(info[1]), info[2], info[3]);
            case "Tiger":
                return new Tiger(info[0], double.Parse(info[1]), info[2], info[3]);
            case "Owl":
                return new Owl(info[0], double.Parse(info[1]), double.Parse(info[2]));
            case "Hen":
                return new Hen(info[0], double.Parse(info[1]), double.Parse(info[2]));
            case "Mouse":
                return new Mouse(info[0], double.Parse(info[1]), info[2]);
            case "Dog":
                return new Dog(info[0], double.Parse(info[1]), info[2]);
            default: throw new ArgumentException();
        }
    }
}