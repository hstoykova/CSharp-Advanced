namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            string input = Console.ReadLine();
            string[] splitted = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int n1 = int.Parse(splitted[0]);
            int n2 = int.Parse(splitted[1]);

            for (int i = 0; i < n1; i++)
            {
                int elements1 = int.Parse(Console.ReadLine());
                first.Add(elements1);
            }

            for (int i = 0; i < n2; i++)
            {
                int elements2 = int.Parse(Console.ReadLine());
                second.Add(elements2);
            }

            Console.WriteLine(string.Join(" ", first.Intersect(second)));
        }
    }
}