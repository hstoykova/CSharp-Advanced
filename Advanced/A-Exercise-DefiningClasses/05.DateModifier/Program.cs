namespace DateModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();

            int diff = DateModifier.CalculateDifference(start, end);

            Console.WriteLine(diff);
        }
    }
}