/*
Alva James William
2 
 
 */


namespace _7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ");
            Queue<string> queue = new Queue <string>(names);

            int rounds = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 0; i < rounds - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}