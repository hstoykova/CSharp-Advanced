using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman;

public class Engine
{
    private string model;
    private int power;
    private int? displacement;
    private string? efficiency;

    public Engine(string model, int power)
    {
        Model = model;
        Power = power;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public int? Displacement
    {
        get { return displacement; }
        set { displacement = value; }
    }

    public string? Efficiency
    {
        get { return efficiency; }
        set { efficiency = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"  {Model}:");
        sb.AppendLine($"    Power: {Power}");
        sb.AppendLine($"    Displacement: {(Displacement is null ? "n/a" : Displacement)}");
        sb.Append($"    Efficiency: {(Efficiency is null ? "n/a" : Efficiency)}");
        return sb.ToString();
    }
}

