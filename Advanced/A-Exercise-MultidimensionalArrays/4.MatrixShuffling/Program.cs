/*
2 3
1 2 3
4 5 6
swap 0 0 1 1
swap 10 9 8 7
swap 0 1 1 0
END

 */

namespace _4.MatrixShuffling
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            // Създаваме матрица
            string[,] matrix = new string[rows, cols];

            // Пълним матрицата с данни
            for (int row = 0; row < rows; row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (IsValid(command, rows, cols))
                {
                    string[] splittedCommand = command.Split(" ");
                    int row1 = int.Parse(splittedCommand[1]);
                    int col1 = int.Parse(splittedCommand[2]);
                    int row2 = int.Parse(splittedCommand[3]);
                    int col2 = int.Parse(splittedCommand[4]);

                    // Swap-ване на данни в матрицата
                    string positionOne = matrix[row1, col1];
                    string positionTwo = matrix[row2, col2];

                    matrix[row1, col1] = positionTwo;
                    matrix[row2, col2] = positionOne;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }



        // Извършване на необходимите проверки
        static bool IsValid(string command, int rows, int cols)
        {
            string[] splittedCommand = command.Split(" ");

            bool isValidName = splittedCommand[0] == "swap";
            bool isValidCountParts = splittedCommand.Length == 5;

            bool isValidRowsAndCols = false;
            if (isValidName && isValidCountParts)
            {
                int row1 = int.Parse(splittedCommand[1]);
                int col1 = int.Parse(splittedCommand[2]);
                int row2 = int.Parse(splittedCommand[3]);
                int col2 = int.Parse(splittedCommand[4]);

                isValidRowsAndCols =
                   row1 >= 0 && row1 < rows
                && col1 >= 0 && col1 < cols
                && row2 >= 0 && row2 < rows
                && col2 >= 0 && col2 < cols;
            }

            return isValidName && isValidCountParts && isValidRowsAndCols; ;
        }
        // Принтиране на матрицата
        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}