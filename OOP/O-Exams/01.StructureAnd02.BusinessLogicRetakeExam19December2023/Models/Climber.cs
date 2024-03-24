using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models;

public abstract class Climber : IClimber
{
    private string name;
    private int stamina;
    private List<string> conqueredPeaks;

    protected Climber(string name, int stamina)
    {
        Name = name;
        Stamina = stamina;
        conqueredPeaks = new();
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
            }
            name = value;
        }
    }

    public int Stamina
    {
        get { return stamina; }
        protected set
        {
            if (value > 10)
            {
                stamina = 10;
                return;
            }
            else if (value < 0)
            {
                stamina = 0;
                return;
            }
            stamina = value;
        }
    }


    public IReadOnlyCollection<string> ConqueredPeaks
    {
        get { return conqueredPeaks.AsReadOnly(); }
        //set { conqueredPeaks = value; }
    }

    public void Climb(IPeak peak)
    {
        if (!conqueredPeaks.Any(p => p == peak.Name))
        {
            conqueredPeaks.Add(peak.Name);
        }

        switch (peak.DifficultyLevel)
        {
            case "Extreme":
                Stamina -= 6;
                break;
            case "Hard":
                Stamina -= 4;
                break;
            case "Moderate":
                Stamina -= 2;
                break;
        }
    }

    public abstract void Rest(int daysCount);

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
        if (conqueredPeaks.Any())
        {
            sb.AppendLine($"Peaks conquered: {conqueredPeaks.Count}");
        }
        else
        {
            sb.AppendLine("Peaks conquered: no peaks conquered");
        }
        return sb.ToString().Trim();
    }
}
