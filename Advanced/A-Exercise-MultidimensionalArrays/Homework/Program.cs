/*
4 5
3 3
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4

 */

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            int[] userDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int searchedRows = userDimensions[0];
            int searchedCols = userDimensions[1];

            for (int row = 0; row < rows; row++) // add data to the matrix
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            int max = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < rows - searchedRows + 1; row++)
            {
                for (int col = 0; col < cols - searchedCols + 1; col++)
                {
                    int sum = 0;
                    for (int i = row; i < searchedRows + row; i++)
                    {
                        for (int j = col; j < searchedCols + col; j++)
                        {
                            sum += matrix[i, j];
                        }
                    }

                    if (sum > max)
                    {
                        max = sum;
                        maxRow = row;
                        maxCol = col;
                    }

                }
            }

            Console.WriteLine($"Sum = {max}");

            for (int i = maxRow; i < maxRow + searchedRows; i++)
            {
                for (int j = maxCol; j < maxCol + searchedCols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}