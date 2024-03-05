using System;
using Vehicles.Factories.IO.Interfaces;

namespace Vehicles.Factories;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string str) => Console.WriteLine(str);
}
