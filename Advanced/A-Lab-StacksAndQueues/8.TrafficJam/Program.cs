/*
4
Hummer H2
Audi
Lada
Tesla
Renault
Trabant
Mercedes
MAN Truck
green
green
Tesla
Renault
Trabant
end

 */

namespace _8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            string input;
            Queue<string> queue = new Queue<string>();
            int count = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < numberOfCars; i++)
                    {
                        if (queue.Any())
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}