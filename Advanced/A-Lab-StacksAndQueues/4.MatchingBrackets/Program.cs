/*
1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5

(2 + 3) - (2 + 3) 
 */

namespace _4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> expression = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    expression.Push(i);
                }

                else if (input[i] == ')')
                {
                    int popped = expression.Pop();
                    //input.Substring(popped, i - popped);
                    Console.WriteLine(input.Substring(popped, i - popped + 1));
                }
            }
        }
    }
}