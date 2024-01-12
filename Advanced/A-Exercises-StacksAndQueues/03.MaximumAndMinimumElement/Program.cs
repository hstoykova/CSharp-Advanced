namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read n numbers from the console
            int n = int.Parse(Console.ReadLine());

            // Create a Stack
            Stack<int> manipulatedStack = new Stack<int>();

            // Use for to check all n numbers
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (input[0])
                {
                    case 1:
                        manipulatedStack.Push(input[1]);
                        break;
                    case 2:
                        manipulatedStack.Pop();
                        break;
                    case 3:
                        if (manipulatedStack.Any())
                        {
                            Console.WriteLine(manipulatedStack.Max());
                        }
                        break;
                    case 4:
                        if (manipulatedStack.Any())
                        {
                            Console.WriteLine(manipulatedStack.Min());
                        }
                        break;
                }
            }

            // Output:
            Console.WriteLine(string.Join(", ", manipulatedStack));
        }
    }
}