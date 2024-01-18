/*
3, 6
7, 1, 3, 3, 2, 1
1, 3, 9, 8, 5, 6
4, 6, 7, 9, 1, 0

 */

namespace _5.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = size[0];
            int cols = size[1];

            // Създаваме матрица
            int[,] matrix = new int[rows, cols];

            // Пълним данни в матрицата
            for (int row = 0; row < rows; row++)
            {
                int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            int maxSquareSum = matrix[0, 0];
            int maxSquareRow = 0;
            int maxSquareCol = 0;

            // Обхождаме матрицата
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > maxSquareSum)
                    {
                        maxSquareSum = sum;
                        maxSquareRow = row;
                        maxSquareCol = col;
                    }
                }
            }
            Console.WriteLine($"{ matrix[maxSquareRow, maxSquareCol]} {matrix[maxSquareRow, maxSquareCol + 1]}");
            Console.WriteLine($"{ matrix[maxSquareRow + 1, maxSquareCol]} {matrix[maxSquareRow + 1, maxSquareCol + 1]}");
            Console.WriteLine(maxSquareSum);
        }
    }
}