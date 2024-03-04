using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.Factories;
using Vehicles.Factories.IO.Interfaces;

namespace Vehicles;

public class StartUp
{
    static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        //IVehicleFactory vehicleFactory = new IVehicleFactory();

        IEngine engine = new Engine(reader, writer);

        engine.Run();
    }
}