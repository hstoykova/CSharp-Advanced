using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models;

public abstract class Fish : IFish
{
    private string name;
    private double points;
    private int timeToCatch;

    public Fish(string name, double points, int timeToCatch) // it was protected, should always be public !!!
    {
        Name = name;
        Points = points;
        TimeToCatch = timeToCatch;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.FishNameNull);
            }
            name = value;
        }
    }
    public double Points
    {
        get { return points; }
        private set
        {
            if (value < 1 || value > 10) // it was with &&
            {
                throw new ArgumentException(ExceptionMessages.PointsNotInRange);
            }
            points = value;
        }
    }

    public int TimeToCatch
    {
        get { return timeToCatch; }
        private set { timeToCatch = value; }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]"; // possible mistake here with typeof(Fish).Name}
        //{typeof(Fish).Name} can be this.GetType().Name;
    }
}
