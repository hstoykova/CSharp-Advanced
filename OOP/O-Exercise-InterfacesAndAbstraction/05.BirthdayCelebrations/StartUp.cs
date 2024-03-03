using System.Reflection;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BorderControl borderControl = new();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splittedCommand = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (splittedCommand[0] == "Robot")
                {
                    Robot robot = new(splittedCommand[2], splittedCommand[1]);
                }
                else if(splittedCommand[0] == "Citizen")
                {
                    Citizen citizen = new(splittedCommand[3], int.Parse(splittedCommand[2]), splittedCommand[1], splittedCommand[4]);
                    borderControl.AddCreatureForBorderCheck(citizen);
                }
                else
                {
                    Pet pet = new(splittedCommand[1], splittedCommand[2]);
                    borderControl.AddCreatureForBorderCheck(pet);
                }
            }

            string year = Console.ReadLine();
            var detained = borderControl.Creatures.Where(e => e.Birthdate.EndsWith(year));

            foreach (var item in detained)
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}