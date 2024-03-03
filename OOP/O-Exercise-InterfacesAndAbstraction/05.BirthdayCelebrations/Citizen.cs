using System;

namespace BirthdayCelebrations;

public class Citizen : ICreature, IIdentifialbe
{
    public Citizen(string id, int age, string name, string birthdate)
    {
        Age = age;
        Name = name;
        Birthdate = birthdate;
        Id = id;
    }

    public int Age { get; private set; }
    public string Name { get; set; }
    public string Birthdate { get; set; }
    public string Id { get; set; }
}
