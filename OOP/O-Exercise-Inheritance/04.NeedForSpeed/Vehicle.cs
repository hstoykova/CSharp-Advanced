
namespace NeedForSpeed;

public class Vehicle
{
	private double defaultFuelConsumption;
    private double fuelConsumption;
    private double fuel;
    private int horsePower;

    public Vehicle(int horsePower, double fuel)
    {
        HorsePower = horsePower;
        Fuel = fuel;
        DefaultFuelConsumption = 1.25;
    }

    public Vehicle(int horsePower, double fuel, double defaultFuelConsumption)
    {
        HorsePower = horsePower;
        Fuel = fuel;
        DefaultFuelConsumption = defaultFuelConsumption;
    }

    public double DefaultFuelConsumption
	{
        get { return defaultFuelConsumption; }
        set { defaultFuelConsumption = value; }
	}

	public virtual double FuelConsumption
	{
		get { return fuelConsumption; }
		set { fuelConsumption = value; }
	}

    public double Fuel
    {
        get { return fuel; }
        set { fuel = value; }
    }
    public int HorsePower
    {
        get { return horsePower; }
        set { horsePower = value; }
    }

   

	public virtual void Drive(double kilometers)
	{
            Fuel -= kilometers * DefaultFuelConsumption;
    }
}
