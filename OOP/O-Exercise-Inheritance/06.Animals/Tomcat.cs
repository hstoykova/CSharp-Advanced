using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals;

public class Tomcat : Cat
{
    private const string tomGender = "male";
    public Tomcat(string name, int age) 
        : base(name, age, tomGender)
    {
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}
