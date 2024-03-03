using System;

namespace BirthdayCelebrations;

public class BorderControl
{
    private List<ICreature> creatures;

    public List<ICreature> Creatures
    {
        get => creatures;
        set => creatures = value;
    }

    public BorderControl()
    {
        Creatures = new List<ICreature>();
    }
    public void AddCreatureForBorderCheck(ICreature creature)
    {
        Creatures.Add(creature);
    }
}
