namespace _01.RubberDuckDebugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> programmerTime = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> numberOfTasks = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int dartDCount = 0;
            int thorDCount = 0;
            int bbRubberDCount = 0;
            int smallYRDCount = 0;

            while (programmerTime.Any() && numberOfTasks.Any())
            {
                int currentTime = programmerTime.Dequeue();
                int currentTask = numberOfTasks.Pop();
                int result = currentTime * currentTask;

                if (result >= 0 && result <= 60)
                {
                    dartDCount++;
                }
                else if (result >= 61 && result <= 120)
                {
                    thorDCount++;
                }
                else if (result >= 121 && result <= 180)
                {
                    bbRubberDCount++;
                }
                else if (result >= 181 && result <= 240)
                {
                    smallYRDCount++;
                }
                else
                {
                    currentTask -= 2;
                    numberOfTasks.Push(currentTask);
                    programmerTime.Enqueue(currentTime);
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {dartDCount}");
            Console.WriteLine($"Thor Ducky: {thorDCount}");
            Console.WriteLine($"Big Blue Rubber Ducky: {bbRubberDCount}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {smallYRDCount}");
        }
    }
}