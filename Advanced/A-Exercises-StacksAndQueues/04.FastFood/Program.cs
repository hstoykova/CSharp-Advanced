/*
348
20 54 30 16 7 9

499
57 45 62 70 33 90 88 76
 */

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int availableFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ordersForTheDay = new Queue<int>(orders);

            Console.WriteLine(ordersForTheDay.Max());

            while (ordersForTheDay.Any())
            {
                if (availableFood >= ordersForTheDay.Peek())
                {
                    availableFood -= ordersForTheDay.Dequeue();
                    //Console.WriteLine("Orders complete");
                }
                else
                {
                    Console.WriteLine("Orders left: " + string.Join(" ", ordersForTheDay));
                    return;
                }              
            }

            Console.WriteLine("Orders complete");
        }
    }
}