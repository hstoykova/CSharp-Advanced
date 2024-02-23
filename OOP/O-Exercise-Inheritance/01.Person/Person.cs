namespace Person;

public class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                age = 0;
            }
            else
            {
                age = value;
            }
        }
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}
