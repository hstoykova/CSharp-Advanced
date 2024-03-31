using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core;

public class Controller : IController
{
    UserRepository users;
    VehicleRepository vehicles;
    RouteRepository routes;

    public Controller()
    {
        users = new();
        vehicles = new();
        routes = new();
    }

    public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
    {
        var user = users.FindById(drivingLicenseNumber);
        if (user is not null)
        {
            return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
        }
        user = new User(firstName, lastName, drivingLicenseNumber);
        users.AddModel(user);
        return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
    }

    public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
    {
        string[] validVehicles = new[] { "CargoVan", "PassengerCar" };

        if (!validVehicles.Contains(vehicleType))
        {
            return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
        }

        var vehicle = vehicles.FindById(licensePlateNumber);

        if (vehicle is not null)
        {
            return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
        }

        if (vehicleType == "CargoVan")
        {
            vehicle = new CargoVan(brand, model, licensePlateNumber);
        }
        else //PassengerCar
        {
            vehicle = new PassengerCar(brand, model, licensePlateNumber);
        }

        vehicles.AddModel(vehicle);
        return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
    }

    public string AllowRoute(string startPoint, string endPoint, double length)
    {
        var route = routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length);
        if (route is not null)
        {
            return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
        }

        var route2 = routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length);
        if (route2 is not null)
        {
            return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
        }

        var newRoute = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
        routes.AddModel(newRoute);

        var route3 = routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length);
        if (route3 is not null)
        {
            route3.LockRoute();
        }

        return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
    }

    public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
    {
        var user = users.FindById(drivingLicenseNumber);
        if (user.IsBlocked)
        {
            return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
        }

        var vehicle = vehicles.FindById(licensePlateNumber);
        if (vehicle.IsDamaged)
        {
            return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
        }

        var route = routes.FindById(routeId);
        if (route.IsLocked)
        {
            return string.Format(OutputMessages.RouteLocked, routeId);
        }


        vehicle.Drive(route.Length);


        if (isAccidentHappened)
        {
            vehicle.ChangeStatus();
            user.DecreaseRating();
        }
        else
        {
            user.IncreaseRating();
        }

        return vehicle.ToString();
    }

    public string RepairVehicles(int count)
    {
        IEnumerable<IVehicle> damaged = vehicles.GetAll().Where(v => v.IsDamaged).OrderBy(v => v.Brand).ThenBy(v => v.Model);
        List<IVehicle> list;

        if (damaged.Count() > count)
        {
            list = damaged.Take(count).ToList();
        }
        else
        {
            list = damaged.ToList();
        }

        foreach (var repaired in list)
        {
            repaired.ChangeStatus();
            repaired.Recharge();
        }

        return string.Format(OutputMessages.RepairedVehicles, list.Count());
    }

    public string UsersReport()
    {
        var lusers = users.GetAll().OrderByDescending(u => u.Rating).ThenBy(u => u.LastName).ThenBy(u => u.FirstName);
        StringBuilder sb = new();
        sb.AppendLine("*** E-Drive-Rent ***");

        foreach (var user in lusers)
        {
            sb.AppendLine(user.ToString());
        }

        return sb.ToString().Trim();
    }
}
