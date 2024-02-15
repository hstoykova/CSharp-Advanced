namespace _02.TheSquirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            int rows = n;
            int cols = n;

            int currentPositionRow = -1;
            int currentPositionCol = -1;

            int hazelnutsCount = 0;

            bool isTrapped = false;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];

                    if (data[col] == 's')
                    {
                        currentPositionRow = row;
                        currentPositionCol = col;
                    }
                }
            }

            foreach (var direction in commands)
            {
                int nextPositionRow = currentPositionRow;
                int nextPositionCol = currentPositionCol;

                if (direction == "up")
                {
                    nextPositionRow -= 1;
                }
                if (direction == "down")
                {
                    nextPositionRow += 1;
                }
                if (direction == "left")
                {
                    nextPositionCol -= 1;
                }
                if (direction == "right")
                {
                    nextPositionCol += 1;
                }

                if (nextPositionRow >= rows || nextPositionCol >= cols || nextPositionRow < 0 || nextPositionCol < 0)
                {
                    isTrapped = true;
                    Console.WriteLine("The squirrel is out of the field.");
                    break;
                }

                currentPositionRow = nextPositionRow;
                currentPositionCol = nextPositionCol;

                char element = matrix[currentPositionRow, currentPositionCol];

                if (element == 't')
                {
                    isTrapped = true;
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    break;
                }

                if (element == 'h')
                {
                    matrix[currentPositionRow, currentPositionCol] = '*';
                    hazelnutsCount++;

                    if (hazelnutsCount == 3)
                    {
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        break;
                    }
                }
            }

            if (!isTrapped && hazelnutsCount < 3)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }

            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
        }
    }
}