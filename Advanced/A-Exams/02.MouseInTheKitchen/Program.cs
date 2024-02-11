namespace _02.MouseInTheKitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = n[0];
            int cols = n[1];

            int currentPositionRow = -1;
            int currentPositionCol = -1;
            int cheeseCount = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];

                    if (data[col] == 'M')
                    {
                        currentPositionRow = row;
                        currentPositionCol = col;
                    }

                    if (data[col] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "danger")
            {
                string direction = command;

                int nextPositionRow = currentPositionRow;
                int nextPositionCol = currentPositionCol;

                //matrix[startPositionRow, startPositionCol] = '.';

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
                    matrix[currentPositionRow, currentPositionCol] = 'M';
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }

                if (matrix[nextPositionRow, nextPositionCol] == '@')
                {
                    continue;
                }

                matrix[currentPositionRow, currentPositionCol] = '*';

                currentPositionRow = nextPositionRow;
                currentPositionCol = nextPositionCol;

                char element = matrix[currentPositionRow, currentPositionCol];

                if (element == 'C')
                {
                    cheeseCount--;
                    matrix[currentPositionRow, currentPositionCol] = '*';

                    if (cheeseCount == 0)
                    {
                        matrix[currentPositionRow, currentPositionCol] = 'M';
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        break;
                    }
                }

                if (element == '*')
                {
                    continue;
                }

                if (element == 'T')
                {
                    matrix[currentPositionRow, currentPositionCol] = 'M';
                    Console.WriteLine("Mouse is trapped!");
                    break;
                }
            }

            if (command == "danger" && cheeseCount > 0)
            {
                Console.WriteLine("Mouse will come back later!");
            }

            //Print matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}