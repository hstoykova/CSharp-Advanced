namespace FoodShortage;

public class StartUp
{
    static void Main(string[] args)
    {
        Dictionary<string, IBuyer> people = new Dictionary<string, IBuyer>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (input.Length == 4)
            {
                Citizen citizen = new(input[0], int.Parse(input[1]), input[2], input[3]);
                people.Add(citizen.Name, citizen);
            }
            else
            {
                Rebel rebel = new(input[0], int.Parse(input[1]), input[2]);
                people.Add(rebel.Name, rebel);
            }
        }

        string personName;

        while ((personName = Console.ReadLine()) != "End")
        {
            if (people.ContainsKey(personName))
            {
                people[personName].BuyFood();
            }
        }

        int totalFood = 0;

        foreach (IBuyer person in people.Values)
        {
            totalFood += person.Food;
        }

        Console.WriteLine(totalFood);
    }
}