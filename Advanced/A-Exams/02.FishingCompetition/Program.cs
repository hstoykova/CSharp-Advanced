namespace _02.FishingCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;

            int startPositionRow = -1;
            int startPositionCol = -1;

            char boatPosition;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];

                    if (data[col] == 'S')
                    {
                        startPositionRow = row;
                        startPositionCol = col;
                    }
                }
            }

            string direction;
            int collectedFish = 0;

            while ((direction = Console.ReadLine()) != "collect the nets")
            {
                matrix[startPositionRow, startPositionCol] = '-'; // possible mistake here

                if (direction == "up")
                {
                    if (startPositionRow - 1 < 0)
                    {
                        startPositionRow += rows - 1;
                    }
                    else
                    {
                        startPositionRow -= 1;
                    }
                }
                if (direction == "down")
                {
                    if (startPositionRow + 1 >= rows)
                    {
                        startPositionRow -= rows - 1;
                    }
                    else
                    {
                        startPositionRow += 1;
                    }
                }
                if (direction == "left")
                {
                    if (startPositionCol - 1 < 0)
                    {
                        startPositionCol += cols - 1;
                    }
                    else
                    {
                        startPositionCol -= 1;

                    }
                }
                if (direction == "right")
                {
                    if (startPositionCol + 1 >= cols)
                    {
                        startPositionCol -= cols - 1;
                    }
                    else
                    {
                        startPositionCol += 1;

                    }
                }

                char element = matrix[startPositionRow, startPositionCol];

                if (char.IsDigit(element))
                {
                    collectedFish += int.Parse(element.ToString());
                    matrix[startPositionRow, startPositionCol] = 'S';
                    continue;
                }

                if (element == 'W')
                {
                    collectedFish = 0;
                    matrix[startPositionRow, startPositionCol] = 'S';
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{startPositionRow},{startPositionCol}]");
                    return;
                }

                if (element == '-')
                {
                    matrix[startPositionRow, startPositionCol] = 'S';
                }
            }

            if (collectedFish >= 20)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
            }
            else
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - collectedFish} tons of fish more.");
            }

            if (collectedFish > 0)
            {
                Console.WriteLine($"Amount of fish caught: {collectedFish} tons.");
            }

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