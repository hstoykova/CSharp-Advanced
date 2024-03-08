using System;

namespace Heroes.Models;

public class Druid : BaseHero
{
    private const int defaultPower = 80;
    public Druid(string name) 
        : base(name, defaultPower)
    {
    }

    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}
