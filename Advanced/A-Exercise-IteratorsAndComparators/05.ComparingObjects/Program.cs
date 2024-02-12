namespace _05.ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] personProp = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new();
                {
                    person.Name = personProp[0];
                    person.Age = int.Parse(personProp[1]);
                    person.Town = personProp[2];
                };

                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person indexPerson = people[index];

            int equalCount = 0;
            int diffCount = 0;

            foreach (Person person in people)
            {
                if (person.CompareTo(indexPerson) == 0)
                {
                    equalCount++;
                }
                else
                {
                    diffCount++;
                }
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {diffCount} {people.Count}");
            }
        }
    }
}