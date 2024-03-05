using System;
using Vehicles.Factories.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories;

public class VehicleFactory : IVehicleFactory
{
    public IVehicle Create(string type, double fuelQuantity, double fuelConsumption)
    {
        switch (type)
        {
            case "Car":
                return new Car(fuelQuantity, fuelConsumption);
            case "Truck":
                return new Truck(fuelQuantity, fuelConsumption);
                break;
            default:
                throw new AggregateException("Invalid vehicle type");
        }
    }
}
