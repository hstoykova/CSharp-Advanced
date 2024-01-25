namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicate = new();

            int endOfRange = int.Parse(Console.ReadLine());

            HashSet<int> dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

            int[] numbers = Enumerable.Range(1, endOfRange).ToArray();

            foreach (var divider in dividers)
            {
                predicate.Add(p => p % divider == 0);
            }

            foreach (var number in numbers)
            {
                bool isDivisible = true;

                foreach (var match in predicate)
                {
                    if (!match(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}