namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> names = new List<string>();
            foreach (string name in input)
            {
                names.Add(name);
            }

            names.ForEach(delegate (string name)
            {
                Console.WriteLine($"Sir {name}");
            });
        }
    }
}