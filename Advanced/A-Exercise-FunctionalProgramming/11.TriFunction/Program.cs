namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkEqualOrLargerNameSum =
                //(name, sum) => name.Sum(ch => ch) >= sum;  OTHER OPTION
                (name, sum) =>
                {
                    int charSum = name.Sum(ch => ch);
                    return charSum >= sum;
                };

            Func<string[], int, Func<string, int, bool>, string> getFirstName =
                //(names, sum, match) => names.FirstOrDefault(name => match(name, sum));  OTHER OPTION OF BELOW FUNC
                (names, sum, match) =>
                {
                    foreach (var name in names)
                    {
                        if (match(name, sum))
                        {
                            return name;
                        }
                    }

                    return default;
                };

            int sum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foundName = getFirstName(names, sum, checkEqualOrLargerNameSum);

            Console.WriteLine(foundName);
        }
    }
}