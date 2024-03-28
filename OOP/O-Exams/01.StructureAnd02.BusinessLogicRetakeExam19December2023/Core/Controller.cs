using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HighwayToPeak.Core;

public class Controller : IController
{
    private PeakRepository peaks;
    private ClimberRepository climbers;
    private BaseCamp baseCamp;

    public Controller()
    {
        peaks = new PeakRepository();
        climbers = new ClimberRepository();
        baseCamp = new BaseCamp();
    }

    string[] validDiffLevels = new[] { "Extreme", "Hard", "Moderate" };
    public string AddPeak(string name, int elevation, string difficultyLevel)
    {
        if (peaks.Get(name) is not null)
        {
            return string.Format(OutputMessages.PeakAlreadyAdded, name);
        }
        if (!validDiffLevels.Contains(difficultyLevel))
        {
            return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
        }

        Peak peak = new(name, elevation, difficultyLevel);
        peaks.Add(peak);
        return string.Format(OutputMessages.PeakIsAllowed, name, typeof(PeakRepository).Name);
    }

    public string NewClimberAtCamp(string name, bool isOxygenUsed)
    {
        //string existingClimber = climbers.Get(name).ToString();

        if (climbers.Get(name) is not null)
        {
            return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, typeof(ClimberRepository).Name);
        }

        IClimber climber;

        if (isOxygenUsed)
        {
            climber = new OxygenClimber(name);
        }
        else
        {
            climber = new NaturalClimber(name);
        }
        climbers.Add(climber);
        baseCamp.ArriveAtCamp(name);
        return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
    }

    public string AttackPeak(string climberName, string peakName)
    {
        IClimber existingClimber = climbers.Get(climberName);

        if (existingClimber is null)
        {
            return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
        }

        IPeak existingPeak = peaks.Get(peakName);

        if (existingPeak is null)
        {
            return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
        }

        if (!baseCamp.Residents.Contains(climberName))
        {
            return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
        }

        // string[] validDiffLevels = new[] { "Extreme", "Hard", "Moderate" };

        //var peak = peaks.Get(peakName);
        //var climber = climbers.Get(climberName);

        if (existingPeak.DifficultyLevel == "Extreme" && existingClimber.GetType().Name == "NaturalClimber")
        {
            return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
        }

        baseCamp.LeaveCamp(climberName);
        existingClimber.Climb(existingPeak);

        if (existingClimber.Stamina <= 0)
        {
            return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
        }
        else
        {
            baseCamp.ArriveAtCamp(climberName);
            return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
        }
    }

    public string CampRecovery(string climberName, int daysToRecover)
    {
        if (!baseCamp.Residents.Contains(climberName))
        {
            return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
        }

        var climber = climbers.Get(climberName);

        if (climber.Stamina == 10) // possible to be >= 10
        {
            return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
        }

        climber.Rest(daysToRecover);
        return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
    }

    public string BaseCampReport()
    {
        StringBuilder sb = new();

        if (baseCamp.Residents.Count == 0)
        {
            sb.AppendLine("BaseCamp is currently empty.");
        }
        else
        {
            sb.AppendLine("BaseCamp residents:");


            foreach (var residentName in baseCamp.Residents)
            {
                var climber = climbers.Get(residentName);

                sb.AppendLine($"Name: {residentName}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }
        }

        return sb.ToString().Trim();
    }

    public string OverallStatistics()
    {
        StringBuilder sb = new();
        sb.AppendLine("***Highway-To-Peak***");

        var sorted = climbers.All
            .OrderByDescending(c => c.ConqueredPeaks.Count)
            .ThenBy(c => c.Name);

        foreach (var climber in sorted)
        {
            sb.AppendLine(climber.ToString());

            var sortedPeaks = climber.ConqueredPeaks.Select(p => peaks.Get(p)).OrderByDescending(s => s.Elevation);

            foreach (var peak in sortedPeaks)
            {
                sb.AppendLine(peak.ToString());
            }
        }

        return sb.ToString().Trim();

    }
}
