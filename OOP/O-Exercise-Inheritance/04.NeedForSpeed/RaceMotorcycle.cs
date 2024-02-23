
namespace NeedForSpeed;

public class RaceMotorcycle : Motorcycle
{
    private const int raceMotorcycleFuelConsumption = 8;
    public RaceMotorcycle(int horsePower, double fuel) 
        : base(horsePower, fuel, raceMotorcycleFuelConsumption)
    {

    }
}
