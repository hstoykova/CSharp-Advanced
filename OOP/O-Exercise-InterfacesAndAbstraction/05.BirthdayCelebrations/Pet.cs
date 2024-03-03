using System;

namespace BirthdayCelebrations;

public class Pet : ICreature
{
    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    public string Name { get; set; }
    public string Birthdate { get; set; }
}
