﻿namespace _06.GenericCountMethodDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double item = double.Parse(Console.ReadLine());
                box.Add(item);
            }

            double itemToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Count(itemToCompare));
        }
    }
}