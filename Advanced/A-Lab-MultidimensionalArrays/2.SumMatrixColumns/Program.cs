/*
3, 6
7 1 3 3 2 1
1 3 9 8 5 6
4 6 7 9 1 0 

3, 3
1 2 3
4 5 6
7 8 9

 */

namespace _2.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int[,] matrix = new int[rows, cols];
            
            //Пълним матрицата с данни от конзолата
            for (int row = 0; row < rows; row++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];                    
                }
            }

            //Калкулиране на сумите по колони
            for (int i = 0; i < cols; i++)
            {
                int colSum = 0;

                for (int j = 0; j < rows; j++)
                {
                    colSum += matrix[j, i];                   
                }
                Console.WriteLine(colSum);
            }
        }
    }
}