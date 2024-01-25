namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

            Func<HashSet<int>, int> minNum = numbers =>
            {
                int min = int.MaxValue;

                foreach (int number in numbers)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }

                return min;
            };

            Console.WriteLine(minNum(numbers));
        }
    }
}