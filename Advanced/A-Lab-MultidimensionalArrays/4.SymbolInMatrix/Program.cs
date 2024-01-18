/*
3
ABC
DEF
X!@
!

 */

namespace _4.SymbolInMatrix;
class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());

        // Създаваме матрица
        string[,] matrix = new string[size, size];

        // Пълним данни в матрицата
        for (int row = 0; row < size; row++)
        {
            string[] data = Console.ReadLine().ToCharArray().Select(char.ToString).ToArray();

            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = data[col];
            }
        }

        string symbol = Console.ReadLine();

        // Обхождаме матрицата
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                string element = matrix[row, col]; // текущ елемент

                if (symbol == element)
                {
                    Console.WriteLine($"({row}, {col})");
                    return;
                }
            }
        }
        Console.WriteLine($"{symbol} does not occur in the matrix");
    }
}
