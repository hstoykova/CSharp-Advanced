using System;
using Vehicles.Factories.IO.Interfaces;

namespace Vehicles.Factories;

public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}
