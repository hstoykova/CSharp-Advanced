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
        Person person = new Person();

        person.Name = "Hristina";
        person.Age = 31;

        Person hrisi = new Person
        {
            Name = "Hristina",
            Age = 31
        };

        Console.WriteLine(person.Name);
    }
}