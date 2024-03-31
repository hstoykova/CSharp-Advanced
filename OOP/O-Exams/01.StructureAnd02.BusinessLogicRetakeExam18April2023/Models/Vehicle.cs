using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models;

public abstract class Vehicle : IVehicle
{
    private string brand;
    private string model;
    private double maxMileage;
    private string licensePlateNumber;
    private int batteryLevel;
    private bool isDamaged;

    protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
    {
        Brand = brand;
        Model = model;
        MaxMileage = maxMileage;
        LicensePlateNumber = licensePlateNumber;
        BatteryLevel = 100;
    }

    public string Brand
    {
        get { return brand; }
        private set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BrandNull);
            }
            brand = value; 
        }
    }   

    public string Model
    {
        get { return model; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNull);
            }
            model = value;
        }
    }

    public double MaxMileage
    {
        get { return maxMileage; }
        private set { maxMileage = value; }
    }

    public string LicensePlateNumber
    {
        get { return licensePlateNumber; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
            }
            licensePlateNumber = value;
        }
    }

    public int BatteryLevel // Set initial value to 100
    {
        get { return batteryLevel; }
        private set { batteryLevel = value; }
    }

    public bool IsDamaged
    {
        get { return isDamaged; }
        private set { isDamaged = value; }
    }
    public void Drive(double mileage)
    {
        int percent = (int)Math.Round(mileage / MaxMileage * 100);

        BatteryLevel -= percent;

        if (this.GetType().Name == "CargoVan")
        {
            BatteryLevel -= 5;
        }
    }

    public void Recharge()
    {
        BatteryLevel = 100;
    }

    public void ChangeStatus()
    {
        IsDamaged = !IsDamaged;
    }

    public override string ToString()
    {
        return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {(IsDamaged ? "OK" : "damaged")}";
    }
}
