/*
1 2 3 4 5
add
add
print
end

 */

using System.Runtime.InteropServices;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, List<int>, List<int>> calculations = (command, numbers) =>
            {
                List<int> result = new();

                foreach (var number in numbers)
                {
                    switch (command)
                    {
                        case "add":
                            result.Add(number + 1);
                            break;
                        case "multiply":
                            result.Add(number * 2);
                            break;
                        case "subtract":
                            result.Add(number - 1);
                            break;
                    }
                }

                return result;
            };

            Action<List<int>> print = numbers =>
                Console.WriteLine(string.Join(" ", numbers));

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    print(numbers);
                }
                else
                {
                    numbers = calculations(command, numbers);
                }
            }
        }
    }
}