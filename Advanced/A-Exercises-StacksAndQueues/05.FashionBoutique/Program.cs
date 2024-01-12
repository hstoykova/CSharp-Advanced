/*
5 4 8 6 3 8 7 7 9
16

1 7 8 2 5 4 7 8 9 6 3 2 5 4 6
20
 */

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());

            int numberOfRacks = 1;
            int currentRackCapacity = rackCapacity;


            while (clothesStack.Any())
            {
                if (clothesStack.Peek() <= currentRackCapacity)
                {
                    currentRackCapacity -= clothesStack.Pop();
                }
                else
                {
                    numberOfRacks++;
                    currentRackCapacity = rackCapacity;
                }
            }

            Console.WriteLine(numberOfRacks);
        }
    }
}