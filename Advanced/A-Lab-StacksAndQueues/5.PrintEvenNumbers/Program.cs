/*
1 2 3 4 5 6

11 13 18 95 2 112 81 46

 */
namespace _5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(input);
            Queue<int> q = new Queue<int>();


            while (queue.Count > 0)
            {
                int element = queue.Dequeue();

                if (element % 2 == 0)
                {
                    q.Enqueue(element);
                }
                
            }
            
            Console.WriteLine(string.Join(", ", q));
        }
    }
}