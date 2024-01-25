namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> reverse = numbers =>
            {
                List<int> result = new List<int>();

                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    result.Add(numbers[i]);
                }

                return result;
            };

            Func<List<int>, Predicate<int>, List<int>> exclude = (numbers, match) =>
                {
                    List<int> result = new();

                    foreach (var number in numbers)
                    {
                        if (!match(number))
                        {
                            result.Add(number);
                        }
                    }

                    return result;
                };

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int n = int.Parse(Console.ReadLine());

            Predicate<int> checkEven = number => number % 2 == 0;

            numbers = exclude(numbers, (int number) =>
            {
                return number % n == 0;
            });

            numbers = reverse(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}