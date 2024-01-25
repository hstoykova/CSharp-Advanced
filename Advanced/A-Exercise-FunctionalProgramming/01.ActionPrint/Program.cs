namespace _01.ActionPrint
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
                Console.WriteLine(name);
            });

            //Another solution(USING Action< T >):

            //Action<string[]> print = strings =>
            //    Console.WriteLine(string.Join(Environment.NewLine, strings));


            //string[] input = Console.ReadLine().
            //    Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //print(input);
        }
    }
}