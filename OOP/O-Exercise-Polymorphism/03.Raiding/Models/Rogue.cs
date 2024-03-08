using System;

namespace Heroes.Models;

public class Rogue : BaseHero
{
    private const int defaultPower = 80;
    public Rogue(string name) 
        : base(name, defaultPower)
    {
    }

    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
