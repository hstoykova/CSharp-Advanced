namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, List<int>> generatedRange = (start, end) =>
            {
                List<int> range = new();

                for (int i = start; i <= end; i++)
                {
                    range.Add(i);
                }

                return range;
            };

            Func<string, int, bool> evenOrOddMatch = (condition, number) =>
            {
                if (condition == "even")
                {
                    return number % 2 == 0;
                }
                else
                {
                    return number % 2 != 0;
                }
            };

            int[] ranges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            List<int> numbers = generatedRange(ranges[0], ranges[1]); 

            foreach (int number in numbers)
            {
                if (evenOrOddMatch (command, number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}