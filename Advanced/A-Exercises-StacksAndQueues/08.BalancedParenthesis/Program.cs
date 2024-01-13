namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> parentheses = new Stack<char>();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if ("({[".Contains(input[i]))
                {
                    parentheses.Push(input[i]);
                }
                else if (input[i] == ')' && parentheses.Peek() == '(')
                {
                    parentheses.Pop();
                }
                else if (input[i] == ']' && parentheses.Peek() == '[')
                {
                    parentheses.Pop();
                }
                else if (input[i] == '}' && parentheses.Peek() == '{')
                {
                    parentheses.Pop();
                }
            }

            if (parentheses.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");

            }
        }
    }
}