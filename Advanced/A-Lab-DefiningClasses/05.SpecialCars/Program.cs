using System.Text;

namespace CarManufacturer;

internal class Program
{
    static void Main(string[] args)
    {
        List<Tire[]> tires = new();
        List<Engine> engines = new();
        List<Car> cars = new();

        string input;

        while ((input = Console.ReadLine()) != "No more tires")
        {
            string[] splittedCommand = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tire[] tInput = new Tire[4];
            int tIndex = 0;

            for (int i = 0; i < splittedCommand.Length; i += 2)
            {
                int year = int.Parse(splittedCommand[i]);
                double capacity = double.Parse(splittedCommand[i + 1]);
                Tire tire = new(year, capacity);

                tInput[tIndex] = tire;
                tIndex++;
            }
            tires.Add(tInput);
        }

        while ((input = Console.ReadLine()) != "Engines done")
        {
            string[] splittedCommand = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int horsePower = int.Parse(splittedCommand[0]);
            double cubicCapacity = double.Parse(splittedCommand[1]);

            Engine engine = new(horsePower, cubicCapacity);
            engines.Add(engine);
        }

        while ((input = Console.ReadLine()) != "Show special")
        {
            string[] splittedCommand = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string make = splittedCommand[0];
            string model = splittedCommand[1];
            int year = int.Parse(splittedCommand[2]);
            int fuelQuantity = int.Parse(splittedCommand[3]);
            double fuelConsumption = double.Parse(splittedCommand[4])/100;
            int engineIndex = int.Parse(splittedCommand[5]);
            int tiresIndex = int.Parse(splittedCommand[6]);

            Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines.ElementAt(engineIndex), tires.ElementAt(tiresIndex));
            cars.Add(car);
        }

        if (cars.Any())
        {
            foreach (var c in cars)
            {
                double pressure = c.Tires.Select(t => t.Pressure).Sum();

                if (c.Year >= 2017 && c.Engine.HorsePower > 330 && pressure > 9 && pressure < 10)
                {
                    c.Drive(20);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Make: {c.Make}");
                    sb.AppendLine($"Model: {c.Model}");
                    sb.AppendLine($"Year: {c.Year}");
                    sb.AppendLine($"HorsePowers: {c.Engine.HorsePower}");
                    sb.AppendLine($"FuelQuantity: {c.FuelQuantity}");

                    Console.Write(sb);
                }
            }
        }
        
    }
}