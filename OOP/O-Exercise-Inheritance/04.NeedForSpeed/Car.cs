

namespace NeedForSpeed;

public class Car : Vehicle
{
    private const int carFuelConsumption = 3;

    public Car(int horsePower, double fuel)
        : base(horsePower, fuel, carFuelConsumption)
    {

    }

    public Car(int horsePower, double fuel, double carFuelConsumption)
        : base(horsePower, fuel, carFuelConsumption)
    {

    }

}    
