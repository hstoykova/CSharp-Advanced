namespace _01.OffroadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> initialFuel = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> consumptionIndex = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> quantitiesNeeded = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            for (int i = 0; i < 4; i++)
            {
                int result = initialFuel.Peek() - consumptionIndex.Peek();

                if (result >= quantitiesNeeded.Peek())
                {
                    initialFuel.Pop();
                    consumptionIndex.Dequeue();
                    quantitiesNeeded.Dequeue();
                    Console.WriteLine($"John has reached: Altitude {i + 1}");

                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {i + 1}");
                    break;
                }
            }

            if (!quantitiesNeeded.Any())
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
                return;
            }

            if (initialFuel.Any() && quantitiesNeeded.Count < 4)
            {
                int reached = 4 - quantitiesNeeded.Count;
                Console.WriteLine("John failed to reach the top.");
                List<string> altitude = new List<string>();

                for (int i = 0; i < reached; i++)
                {
                    altitude.Add($"Altitude {i + 1}");
                }

                Console.WriteLine($"Reached altitudes: {string.Join(", ", altitude)}");
            }
            else
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine("John didn't reach any altitude.");
            }
        }
    }
}