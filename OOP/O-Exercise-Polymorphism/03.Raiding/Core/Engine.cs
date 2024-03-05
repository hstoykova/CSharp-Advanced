﻿using System;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.Factories.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IVehicleFactory vehicleFactory;

    private readonly ICollection<IVehicle> vehicles;

    public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.vehicleFactory = vehicleFactory;
        vehicles = new List<IVehicle>();
    }
    public void Run()
    {    
        vehicles.Add(CreateVehicle());
        vehicles.Add(CreateVehicle());

        int commandsCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            try
            {
                ProcessCommand();
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message); ;
            }
        }

        foreach (var vehicle in vehicles)
        {
            writer.WriteLine(vehicle.ToString());
        }
    }

    private IVehicle CreateVehicle()
    {
        string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        IVehicle vehicle = vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]));
        return vehicle;
    }
    private void ProcessCommand()
    {
        string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string command = commandTokens[0];
        string vehicleType = commandTokens[1];

        IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

        if (command == "Drive")
        {
            double distance = double.Parse(commandTokens[2]);
            writer.WriteLine(vehicle.Drive(distance));
        }
        else if(command == "Refuel")
        {
            double amount = double.Parse(commandTokens[2]);
            vehicle.Refuel(amount);  
        }
    }
}
