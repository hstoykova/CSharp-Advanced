using System;

namespace Heroes.Models;

public class Warrior : BaseHero
{
    private const int defaultPower = 100;
    public Warrior(string name) 
        : base(name, defaultPower)
    {
    }

    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
