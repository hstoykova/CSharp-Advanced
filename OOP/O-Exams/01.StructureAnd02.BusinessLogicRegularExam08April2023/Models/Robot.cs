using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models;

public abstract class Robot : IRobot
{
    private string model;
    private int batteryCapacity;
    private int batteryLevel;
    private int convertionCapacityIndex;
    private List<int> robotStandards;

    public Robot(string model, int batteryCapacity, int convertionCapacityIndex)
    {
        Model = model;
        BatteryCapacity = batteryCapacity;
        ConvertionCapacityIndex = convertionCapacityIndex;

        BatteryLevel = BatteryCapacity;
        robotStandards = new List<int>();
    }

    public string Model
    {
        get { return model; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
            }
            model = value;
        }
    }


    public int BatteryCapacity
    {
        get { return batteryCapacity; }
        private set
        {
            if (batteryCapacity < 0)
            {
                throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
            }
            batteryCapacity = value;
        }
    }

    public int BatteryLevel
    {
        get { return batteryLevel; }
        private set { batteryLevel = value; }
    }


    public int ConvertionCapacityIndex
    {
        get { return convertionCapacityIndex; }
        private set { convertionCapacityIndex = value; }
    }


    public IReadOnlyCollection<int> InterfaceStandards
    {
        get { return robotStandards.AsReadOnly(); }
        //set { robots = value; }
    }


    public void Eating(int minutes)
    {
        int totalCapacity = convertionCapacityIndex * minutes;

        if (totalCapacity > BatteryCapacity - BatteryLevel)
        {
            batteryLevel = batteryCapacity;
        }
        else
        {
            batteryLevel += totalCapacity;
        }
    }

    public void InstallSupplement(ISupplement supplement)
    {
        robotStandards.Add(supplement.InterfaceStandard);
        BatteryCapacity -= supplement.BatteryUsage;
        BatteryLevel -= supplement.BatteryUsage;
    }

    public bool ExecuteService(int consumedEnergy)
    {
        if (BatteryLevel >= consumedEnergy)
        {
            BatteryLevel -= consumedEnergy;
            return true;
        }
            return false;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{this.GetType().Name} {Model}:");
        sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
        sb.AppendLine($"--Current battery level: {BatteryLevel}");

        string standards;

        if (!InterfaceStandards.Any())
        {
            standards = "none";
        }
        else
        {
            standards = string.Join(" ", InterfaceStandards);
        }

        sb.AppendLine($"--Supplements installed: {standards}");

        return sb.ToString().Trim();
    }
}
