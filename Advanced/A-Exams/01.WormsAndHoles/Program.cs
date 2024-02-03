namespace _01.WormsAndHoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] worms = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] holes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> wormsStack = new Stack<int>(worms);
            Queue<int> holesQueue = new Queue<int>(holes);

            int matches = 0;
            int wormsCount = wormsStack.Count;

            while (wormsStack.Any() && holesQueue.Any())
            {
                int worm = wormsStack.Peek();
                int hole = holesQueue.Peek();

                if (worm == hole)
                {
                    wormsStack.Pop();
                    holesQueue.Dequeue();
                    matches++;
                    continue;
                }               
                    holesQueue.Dequeue();
                    wormsStack.Push(wormsStack.Pop() - 3); 

                if (wormsStack.Peek() <= 0)
                {
                    wormsStack.Pop();
                }
            }

            if (matches > 0)
            {
                Console.WriteLine($"Matches: {matches}");
            }
            else
            {
                Console.WriteLine("There are no matches.");
            }

            if (!wormsStack.Any())
            {
                if (matches == wormsCount)
                {
                    Console.WriteLine("Every worm found a suitable hole!");
                }
                else
                {
                    Console.WriteLine("Worms left: none");
                }
            }
            else
            {
                Console.WriteLine($"Worms left: {string.Join(", ", wormsStack)}");
            }

            if (!holesQueue.Any())
            {
                Console.WriteLine("Holes left: none");
            }
            else
            {
                Console.WriteLine($"Holes left: {string.Join(", ", holesQueue)}");
            }
        }
    }
}