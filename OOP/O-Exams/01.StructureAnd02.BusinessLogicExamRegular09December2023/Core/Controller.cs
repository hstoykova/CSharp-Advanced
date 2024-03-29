using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Core;

public class Controller : IController
{
    private DiverRepository diversRepo;
    private FishRepository fishRepo;
    public Controller()
    {
        diversRepo = new DiverRepository();
        fishRepo = new FishRepository();
    }

    public string DiveIntoCompetition(string diverType, string diverName)
    {
        if (diverType != "FreeDiver" && diverType != "ScubaDiver")
        {
            return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
        }

        if (diversRepo.GetModel(diverName) is not null)
        {
            return string.Format(OutputMessages.DiverNameDuplication, diverName, diversRepo.GetType().Name);
        }

        IDiver diver;

        if (diverType == "FreeDiver")
        {
            diver = new FreeDiver(diverName);
        }
        else
        {
            diver = new ScubaDiver(diverName);
        }

        diversRepo.AddModel(diver);

        return string.Format(OutputMessages.DiverRegistered, diverName, diversRepo.GetType().Name);

    }

    public string SwimIntoCompetition(string fishType, string fishName, double points)
    {
        if (fishType != "ReefFish" && fishType != "DeepSeaFish" && fishType != "PredatoryFish")
        {
            return string.Format(OutputMessages.FishTypeNotPresented, fishType);
        }

        if (fishRepo.GetModel(fishName) is not null)
        {
            return string.Format(OutputMessages.FishNameDuplication, fishName, fishRepo.GetType().Name);
        }

        IFish fish;

        if (fishType == "ReefFish")
        {
            fish = new ReefFish(fishName, points);
        }
        else if (fishType == "DeepSeaFish")
        {
            fish = new DeepSeaFish(fishName, points);
        }
        else // PredatoryFish
        {
            fish = new PredatoryFish(fishName, points);
        }

        fishRepo.AddModel(fish);

        return string.Format(OutputMessages.FishCreated, fishName);
    }

    public string ChaseFish(string diverName, string fishName, bool isLucky)
    {
        var existingDiver = diversRepo.GetModel(diverName);

        if (existingDiver is null)
        {
            return string.Format(OutputMessages.DiverNotFound, diversRepo.GetType().Name, diverName);
        }

        var existingFish = fishRepo.GetModel(fishName);

        if (existingFish is null)
        {
            return string.Format(OutputMessages.FishNotAllowed, fishName);
        }

        if (existingDiver.HasHealthIssues)
        {
            return string.Format(OutputMessages.DiverHealthCheck, diverName);
        }

        if (existingDiver.OxygenLevel < existingFish.TimeToCatch)
        {
            existingDiver.Miss(existingFish.TimeToCatch);
            if (existingDiver.OxygenLevel <= 0)
            {
                existingDiver.UpdateHealthStatus();
            }
            return string.Format(OutputMessages.DiverMisses, diverName, fishName);
        }

        if (existingDiver.OxygenLevel == existingFish.TimeToCatch)
        {
            if (isLucky)
            {
                existingDiver.Hit(existingFish);
                if (existingDiver.OxygenLevel <= 0)
                {
                    existingDiver.UpdateHealthStatus();
                }
                return string.Format(OutputMessages.DiverHitsFish, diverName, existingFish.Points, fishName);
            }
            else
            {
                existingDiver.Miss(existingFish.TimeToCatch);
                if (existingDiver.OxygenLevel <= 0)
                {
                    existingDiver.UpdateHealthStatus();
                }
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
        }

        existingDiver.Hit(existingFish);

        if (existingDiver.OxygenLevel <= 0)
        {
            existingDiver.UpdateHealthStatus();
        }

        return string.Format(OutputMessages.DiverHitsFish, diverName, existingFish.Points, fishName);
    }

    public string HealthRecovery()
    {
        int count = 0;

        foreach (var diver in diversRepo.Models)
        {
            if (diver.HasHealthIssues)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
                count++;
            }
        }

        return string.Format(OutputMessages.DiversRecovered, count);
    }

    public string DiverCatchReport(string diverName)
    {
        var diver = diversRepo.GetModel(diverName);

        StringBuilder sb = new();
        sb.AppendLine(diver.ToString());
        sb.AppendLine("Catch Report:");

        foreach (var fishName in diver.Catch)
        {
            var fish = fishRepo.GetModel(fishName);

            sb.AppendLine(fish.ToString());
        }

        return sb.ToString().Trim();
    }

    public string CompetitionStatistics()
    {
        StringBuilder sb = new();
        sb.AppendLine("**Nautical-Catch-Challenge**");

        var sortedDivers = diversRepo.Models.OrderByDescending(d => d.CompetitionPoints)
            .ThenByDescending(d => d.Catch.Count)
            .ThenBy(d => d.Name);

        foreach (var diver in sortedDivers)
        {
            if (!diver.HasHealthIssues)
            {
                sb.AppendLine(diver.ToString());
            }
        }

        return sb.ToString().Trim();
    }
}
