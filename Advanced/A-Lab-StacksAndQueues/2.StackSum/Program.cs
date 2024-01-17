/*
1 2 3 4
adD 5 6
REmove 3
eNd

3 5 8 4 1 9
add 19 32
remove 10
add 89 22
remove 4
remove 3
end

 */

namespace _2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> elements = new Stack<int>(input);
            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] splittedCommand = command.Split(' ');

                if (splittedCommand[0].ToLower() == "add")
                {
                    elements.Push(int.Parse(splittedCommand[1]));
                    elements.Push(int.Parse(splittedCommand[2]));
                }

                if (splittedCommand[0].ToLower() == "remove")
                {
                    int countToPop = int.Parse(splittedCommand[1]);

                    if (countToPop <= elements.Count)
                    {

                        for (int i = 0; i < countToPop; i++)
                        {
                            elements.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {elements.Sum()}");
        }
    }
}