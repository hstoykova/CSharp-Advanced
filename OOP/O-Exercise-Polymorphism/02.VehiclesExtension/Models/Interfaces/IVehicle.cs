using System;

namespace Vehicles.Models.Interfaces;

public interface IVehicle
{
    double FuelQuantity { get; }
    double FuelConsumption { get; }

    string Drive(double distance, bool isIncreasedConsumption = true);
    void Refuel(double amount);
}
