

namespace NeedForSpeed;

public class SportCar : Car
{
    private const int sportCarFuelConsumption = 10;

    public SportCar(int horsePower, double fuel) 
        : base(horsePower, fuel, sportCarFuelConsumption)
    {
    }

}
