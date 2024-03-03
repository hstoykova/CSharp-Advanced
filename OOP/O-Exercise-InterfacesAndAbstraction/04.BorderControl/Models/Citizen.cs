using BorderControl.Models.Interfaces;
using System;

namespace BorderControl.Models;

public class Citizen : BaseEntity
{
    public Citizen(string id, int age, string name)
        : base(id)
    {
        Age = age;
        Name = name;
    }

    public int Age { get;private set; }
    public string Name { get; set; }
}
