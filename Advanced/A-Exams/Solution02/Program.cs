namespace Solution02
{
    // 02. Clear Skies
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rows = n;
            int cols = n;

            char[,] matrix = new char[rows, cols];

            int currentPositionRow = -1;
            int currentPositionCol = -1;

            int enemyCount = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];

                    if (data[col] == 'J')
                    {
                        currentPositionRow = row;
                        currentPositionCol = col;
                    }
                    if (data[col] == 'E')
                    {
                        enemyCount++;
                    }
                }
            }

            int armor = 300;

            while (true)
            {
                matrix[currentPositionRow, currentPositionCol] = '-';

                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    currentPositionRow -= 1;
                }
                if (direction == "down")
                {
                    currentPositionRow += 1;
                }
                if (direction == "left")
                {
                    currentPositionCol -= 1;
                }
                if (direction == "right")
                {
                    currentPositionCol += 1;
                }

                char element = matrix[currentPositionRow, currentPositionCol];

                if (element == '-')
                {
                    matrix[currentPositionRow, currentPositionCol] = 'J';
                    continue;
                }

                if (element == 'E')
                {
                    enemyCount -= 1;

                    matrix[currentPositionRow, currentPositionCol] = 'J';

                    if (enemyCount == 0)
                    {
                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                        break;
                    }
                    else
                    {
                        armor -= 100;

                        if (armor == 0)
                        {
                            Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentPositionRow}, {currentPositionCol}]!");
                            break;
                        }
                    }
                }

                if (element == 'R')
                {
                    armor = 300;
                    matrix[currentPositionRow, currentPositionCol] = 'J';
                }
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