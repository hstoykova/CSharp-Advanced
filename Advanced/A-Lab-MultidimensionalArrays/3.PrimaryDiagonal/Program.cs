/*
3
11 2 4
4 5 6
10 8 -12

 */

namespace _3.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            // Създаваме матрица
            int[,] matrix = new int[size, size];

            // Пълним данни в матрицата
            for (int row = 0; row < size; row++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            int primary = 0;

            // Обхождаме матрицата
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int element = matrix[row, col]; // текущ елемент

                    if (row == col)
                    {
                        primary += element;
                    }                   
                }
            }

            Console.WriteLine(primary);
        }
    }
}