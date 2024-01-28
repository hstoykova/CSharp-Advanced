using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);
            family.AddMember(person);
        }

        Person oldest = family.GetOldestMember();
        Console.WriteLine($"{oldest.Name} {oldest.Age}");
    }
}