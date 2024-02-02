using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman;

public class Car
{
    private string model;
    private Engine engine;
    private int? weight;
    private string? color;

    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }


    public int? Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string? Color
    {
        get { return color; }
        set { color = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{Model}:");
        sb.AppendLine(Engine.ToString());
        sb.AppendLine($"  Weight: {(Weight is null ? "n/a" : Weight)}");
        sb.AppendLine($"  Color: {(Color is null ? "n/a" : Color)}");
        return sb.ToString();
    }
}
