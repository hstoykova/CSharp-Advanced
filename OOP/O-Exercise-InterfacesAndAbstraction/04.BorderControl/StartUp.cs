using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Models.BorderControl borderControl = new();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splittedCommand = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (splittedCommand.Length == 2)
                {
                    Robot robot = new(splittedCommand[1], splittedCommand[0]);
                    borderControl.AddEntityForBorderCheck(robot);
                }
                else
                {
                    Citizen citizen = new(splittedCommand[2], int.Parse(splittedCommand[1]), splittedCommand[0]);
                    borderControl.AddEntityForBorderCheck(citizen);
                }
            }

            string fakeIdEnd = Console.ReadLine();
            var detained = borderControl.EntitiesToBeChecked.Where(e => e.Id.EndsWith(fakeIdEnd));

            foreach (var item in detained)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}