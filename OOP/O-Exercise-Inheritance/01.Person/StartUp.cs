using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age > 15)
            {
                Person person = new(name, age);
                person.Age = age;
                person.Name = name;
                Console.WriteLine(person.ToString());
            }
            else
            {
                Child child = new(name, age);
                child.Age = age;
                child.Name = name;
                Console.WriteLine(child.ToString());
            }
        }
    }
}