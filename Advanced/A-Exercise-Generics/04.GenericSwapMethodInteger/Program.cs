﻿namespace _04.GenericSwapMethodInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> items = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int item = int.Parse(Console.ReadLine());
                items.Add(item);
            }

            int[] indices = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Swap(indices[0], indices[1], items);

            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }

            static void Swap<T>(int firstIndex, int secondIndex, List<T> items)
            {
                (items[secondIndex], items[firstIndex]) = (items[firstIndex], items[secondIndex]);               
            }
        }
    }
}