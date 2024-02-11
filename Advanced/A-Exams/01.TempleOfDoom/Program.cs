using System.Text;

namespace _01.TempleOfDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> substances = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            List<int> challenges = new List<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (tools.Any() && substances.Any())
            {
                int toolElement = tools.Dequeue();
                int substanceElement = substances.Pop();

                int result = toolElement * substanceElement;


                if (challenges.Contains(result))
                {
                    challenges.Remove(result);
                }

                else
                {
                    //toolElement += 1;
                    tools.Enqueue(toolElement + 1);

                    substanceElement -= 1;

                    if (substanceElement > 0)
                    {
                        substances.Push(substanceElement);
                    }
                }

            }

            if (challenges.Any())
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Any())
            {
                StringBuilder sb = new();
                sb.Append("Tools: ");
                string joined = string.Join(", ", tools);
                sb.Append(joined);

                Console.WriteLine(sb);
            }

            if (substances.Any())
            {
                StringBuilder sb = new();
                sb.Append("Substances: ");
                string joined = string.Join(", ", substances);
                sb.Append(joined);

                Console.WriteLine(sb);
            }

            if (challenges.Any())
            {
                StringBuilder sb = new();
                sb.Append("Challenges: ");
                string joined = string.Join(", ", challenges);
                sb.Append(joined);

                Console.WriteLine(sb);
            }
        }
    }
}