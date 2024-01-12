using System.Linq;

namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            // Add elements to the Queue:
            Queue<int> integerQueue = new Queue<int>(secondLine);

            // Remove elements from the Queue
            for (int i = 0; i < firstLine[1]; i++)
            {
                integerQueue.Dequeue();
            }
            
            // Do the checks and the output:
            if (integerQueue.Contains(firstLine[2]))
            {
                Console.WriteLine("true");
            }
            else if (integerQueue.Any())
            {
                Console.WriteLine(integerQueue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}