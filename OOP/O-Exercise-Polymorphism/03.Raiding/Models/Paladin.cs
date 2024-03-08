using System;

namespace Heroes.Models;

public class Paladin : BaseHero
{
    private const int defaultPower = 100;
    public Paladin(string name) 
        : base(name, defaultPower)
    {

    }

    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}
