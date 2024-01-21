namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }
            }

            int output = numbers.Where(x=>x.Value % 2 == 0).First().Key;
            Console.WriteLine(output);
        }
    }
}