/*
-2.5 4 3 -2.5 -5.5 4 3 3 -2.5 3
2 4 4 5 5 2 3 3 4 4 3 3 4 3 5 3 2 5 4 3
 */

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> occurrences = new Dictionary<string, int>();

            foreach(var i in input)
            {
                if (occurrences.ContainsKey(i))
                {
                    occurrences[i]++;
                }
                else
                {
                    occurrences.Add(i, 1);
                }
            }

            foreach (var o in occurrences)
            {
                Console.WriteLine($"{o.Key} - {o.Value} times");
            }
        }
    }
}