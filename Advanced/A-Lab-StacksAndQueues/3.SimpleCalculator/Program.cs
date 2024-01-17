/*
2 + 5 + 10 - 2 - 1

2 - 2 + 5 

 */

namespace _3.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ").Reverse().ToArray();
            Stack<string> numbers = new Stack<string>(input);

            int currentResult = int.Parse(numbers.Pop());

            while (numbers.Count > 0)
            {
                string operation = numbers.Pop();
                int currNumber = int.Parse(numbers.Pop());

                switch (operation)
                {
                    case "-":
                        currentResult -= currNumber;
                        break;
                    case "+":
                        currentResult += currNumber;
                        break;
                }
            }

            Console.WriteLine(currentResult);
        }
    }
}