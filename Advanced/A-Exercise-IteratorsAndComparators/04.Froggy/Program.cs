namespace _04.Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Lake lake = new Lake(list);

            string result = string.Join(", ", lake);
            Console.WriteLine(result);
        }
    }
}