namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (symbols.ContainsKey(input[i]))
                {
                    symbols[input[i]]++;
                }
                else
                {
                    symbols.Add(input[i], 1);
                }
            }

            foreach (var symbol in symbols.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}