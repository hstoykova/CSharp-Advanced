/*
3
1 5
10 3
3 4

 */

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            Queue<int[]> pumpQueue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pairs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumpQueue.Enqueue(pairs);              
            }

            int position = 0;

            while (true)
            {
                int fuel = 0;

                foreach (var pump in pumpQueue)
                {
                    fuel += pump[0] - pump[1];

                    if (fuel < 0)
                    {
                        position++;
                        pumpQueue.Enqueue(pumpQueue.Dequeue());
                        break;
                    }                  
                }

                if (fuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(position);
        }
    }
}