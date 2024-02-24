

namespace Animals;

public class Kitten : Cat
{
    private const string kitGender = "female";

    public Kitten(string name, int age) 
        : base(name, age, kitGender)
    {
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}
