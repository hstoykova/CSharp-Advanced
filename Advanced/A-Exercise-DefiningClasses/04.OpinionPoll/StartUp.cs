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

        List<Person> names = new();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);

            if (person.Age > 30)
            {
                names.Add(person);
            }
        }

        foreach (var name in names.OrderBy(n => n.Name))
        {
            Console.WriteLine($"{name.Name} - {name.Age}");
        }
    }
}