using System.Text;

namespace AutomotiveRepairShop;

public class RepairShop
{
    public RepairShop(int capacity)
    {
        Capacity = capacity;
        Vehicles = new List<Vehicle>();
    }

    public int Capacity { get; set; }

    public List<Vehicle> Vehicles { get; set; }

    public void AddVehicle(Vehicle vehicle)
    {
        if (Capacity > Vehicles.Count)
        {
            Vehicles.Add(vehicle);
        }
    }

    public bool RemoveVehicle(string vin)
    {
        Vehicle? vehicle = Vehicles.Find(v => v.VIN == vin);

        if (vehicle != null)
        {
            Vehicles.Remove(vehicle);
            return true;
        }
        return false;
    }

    public int GetCount()
    {
        return Vehicles.Count;
    }

    public Vehicle GetLowestMileage()
    {
        return  Vehicles.OrderBy(v => v.Mileage).First();
    }

    public string Report()
    {
        StringBuilder sb = new();
        sb.AppendLine("Vehicles in the preparatory:");

        foreach (Vehicle vehicle in Vehicles)
        {
            sb.AppendLine(vehicle.ToString());
        }

        return sb.ToString().TrimEnd();
    }

}
