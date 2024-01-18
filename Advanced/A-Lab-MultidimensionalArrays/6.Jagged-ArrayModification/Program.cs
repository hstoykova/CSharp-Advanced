/*
3
1 2 3
4 5 6 7
8 9 10
Add 0 0 5
Subtract 1 2 2
Subtract 1 4 7
END

 */

namespace _6.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rowsCount][];

            //Пълним матрицата с данни от конзолата
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] splitted = command.Split();
                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length) // jaggedArray[row].Length - брой колони
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (splitted[0] == "Add")
                {
                    jaggedArray[row] [col] += value;
                }
                else
                {
                    jaggedArray[row][col] -= value;
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}