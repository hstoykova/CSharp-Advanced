namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in elements)
                {
                    set.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", set.OrderBy(x=>x)));
        }
    }
}