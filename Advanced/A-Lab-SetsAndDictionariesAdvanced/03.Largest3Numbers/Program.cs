namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine($"{string.Join(" ", numbers.OrderByDescending(n=>n).Take(3))}");
        }
    }
}