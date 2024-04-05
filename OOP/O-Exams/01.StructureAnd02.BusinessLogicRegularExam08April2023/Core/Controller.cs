using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core;

public class Controller : IController
{
    private SupplementRepository supplements;
    private RobotRepository robots;

    public Controller()
    {
        supplements = new SupplementRepository();
        robots = new RobotRepository();
    }

    public string CreateRobot(string model, string typeName)
    {
        string[] valid = new[] { "DomesticAssistant", "IndustrialAssistant" };

        if (!valid.Contains(typeName))
        {
            return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
        }

        IRobot robot;

        if (typeName == "DomesticAssistant")
        {
            robot = new DomesticAssistant(model);
        }
        else //IndustrialAssistant
        {
            robot = new IndustrialAssistant(model);
        }

        robots.AddNew(robot);
        return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
    }

    public string CreateSupplement(string typeName)
    {
        string[] valid = new[] { "SpecializedArm", "LaserRadar" };

        if (!valid.Contains(typeName))
        {
            return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
        }

        ISupplement supplement;

        if (typeName == "SpecializedArm")
        {
            supplement = new SpecializedArm();
        }
        else //LaserRadar
        {
            supplement = new LaserRadar();
        }

        supplements.AddNew(supplement);
        return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
    }

    public string UpgradeRobot(string model, string supplementTypeName)
    {
        ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
        int interfaceStandard = supplement.InterfaceStandard;
        List<IRobot> collection = robots.Models()
            .Where(r => r.InterfaceStandards.All(i => i != interfaceStandard))
            .Where(r => r.Model == model)
            .ToList();

        if (!collection.Any())
        {
            return string.Format(OutputMessages.AllModelsUpgraded, model);
        }

        IRobot robot = collection.First();
        robot.InstallSupplement(supplement);
        supplements.RemoveByName(supplementTypeName);
        return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
    }

    public string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded)
    {
        List<IRobot> collection = robots.Models()
            .Where(r => r.InterfaceStandards.Contains(interfaceStandard))
            .ToList();

        if (!collection.Any())
        {
            return string.Format(OutputMessages.UnableToPerform, interfaceStandard);
        }
        var ordered = collection.OrderByDescending(r => r.BatteryLevel).ToArray();
        int sum = ordered.Select(r => r.BatteryLevel).Sum();

        if (sum < totalPowerNeeded)
        {
            return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sum);
        }

        int count = 0;
        int needed = totalPowerNeeded;

        while (needed > 0)
        {
            if (ordered[count].BatteryLevel >= needed)
            {
                ordered[count].ExecuteService(needed);
                needed = 0;
            }
            else
            {
                needed -= ordered[count].BatteryLevel;
                ordered[count].ExecuteService(ordered[count].BatteryLevel);
            }
            count++;
        }
        return string.Format(OutputMessages.PerformedSuccessfully, serviceName, count);
    }

    public string RobotRecovery(string model, int minutes)
    {
        List<IRobot> hungry = robots.Models().Where(r => r.Model == model).Where(r => r.BatteryLevel < 50).ToList();
        int fed = 0;

        foreach (var rob in hungry)
        {
            int currentBat = rob.BatteryLevel;
            rob.Eating(minutes);

            if (rob.BatteryLevel > currentBat) {
                fed++;
            }
        }

        return string.Format(OutputMessages.RobotsFed, fed);
    }

    public string Report()
    {
        var newCollection = robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity);
        StringBuilder sb = new();

        foreach (var rob in newCollection)
        {
            sb.AppendLine(rob.ToString());
        }

        return sb.ToString().Trim();
    }
}
