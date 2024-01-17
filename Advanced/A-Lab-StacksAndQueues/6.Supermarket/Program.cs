/*
Liam
Noah
James
Paid
Oliver
Lucas
Logan
Tiana
End

 */

namespace _6.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Queue<string> queue = new Queue<string>();

            while((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    Console.WriteLine(string.Join("\n", queue));
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");

        }
    }
}