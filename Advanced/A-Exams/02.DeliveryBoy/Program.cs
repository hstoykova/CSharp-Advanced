using System.Xml.Linq;

namespace _02.DeliveryBoy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = n[0];
            int cols = n[1];

            int startPositionRow = 0;
            int startPositionCol = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];

                    if (data[col] == 'B')
                    {
                        startPositionRow = row;
                        startPositionCol = col;
                    }
                }
            }

            int initialPositionRow = startPositionRow;
            int initialPositionCol = startPositionCol;

            string direction;

            //bool isDelivered = false;

            while (true)
            {
                direction = Console.ReadLine();

                int nextPositionRow = startPositionRow;
                int nextPositionCol = startPositionCol;

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
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    matrix[initialPositionRow, initialPositionCol] = ' ';
                    break;
                }
                
                if (matrix[nextPositionRow, nextPositionCol] == '*')
                {
                    continue;
                }

                startPositionRow = nextPositionRow;
                startPositionCol = nextPositionCol;

                char element = matrix[nextPositionRow, nextPositionCol];

                if (element == 'A')
                {
                    matrix[startPositionRow, startPositionCol] = 'P';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }
                else if (element == 'P')
                {
                    matrix[startPositionRow, startPositionCol] = 'R';
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                    continue;
                }
                else if (element == '-')
                {
                    matrix[startPositionRow, startPositionCol] = '.';
                    continue;
                }


            }
            // Print matrix
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