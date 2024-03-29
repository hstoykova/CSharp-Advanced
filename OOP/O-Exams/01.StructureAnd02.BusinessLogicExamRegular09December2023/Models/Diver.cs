using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models;

public abstract class Diver : IDiver
{
    private string name;
    private int oxygenLevel;
    private List<string> caughtFish;
    private double competitionPoints;
    private bool hasHealthIssues;

    public Diver(string name, int oxygenLevel) // Possible mistake here
    {
        Name = name;
        OxygenLevel = oxygenLevel;
        caughtFish = new();
        CompetitionPoints = 0;
        HasHealthIssues = false;
    }

    public string Name
    {
        get { return name; }
        private set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.DiversNameNull);
            }
            name = value; 
        }
    }

    public int OxygenLevel
    {
        get { return oxygenLevel; }
        protected set  // should be protected set because we need to set it in his children
        {
            if (value < 0)
            {
                value = 0;
            }
            oxygenLevel = value; 
        }
    }

    public IReadOnlyCollection<string> Catch
    {
        get { return caughtFish.AsReadOnly(); }
    }

    public double CompetitionPoints
    {
        get { return competitionPoints;  }
        private set { competitionPoints = value; }
    }

    public bool HasHealthIssues
    {
        get { return hasHealthIssues; }
        private set { hasHealthIssues = value; }
    }

    public void Hit(IFish fish)
    {
        OxygenLevel -= fish.TimeToCatch;
        caughtFish.Add(fish.Name);
        competitionPoints += fish.Points;
    }

    public abstract void Miss(int TimeToCatch);

    public abstract void RenewOxy();

    public void UpdateHealthStatus()
    {
        HasHealthIssues = !HasHealthIssues;
    }
    public override string ToString()
    {
        return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {caughtFish.Count}, Points earned: {Math.Round(CompetitionPoints, 1)} ]";
    }
}
