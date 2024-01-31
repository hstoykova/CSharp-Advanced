namespace _07.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = command[0];
                //int speed = int.Parse(command[1]);
                //int power = int.Parse(command[2]);
                Engine engine = new();
                engine.Speed = int.Parse(command[1]);
                engine.Power = int.Parse(command[2]);

                Cargo cargo = new();
                cargo.Weight = int.Parse(command[3]);
                cargo.Type = command[4];

                Tire[] tires = new Tire[4]
                {
                    new Tire {Pressure = double.Parse(command[5]), Age = int.Parse(command[6])},
                    new Tire {Pressure = double.Parse(command[7]), Age = int.Parse(command[8])},
                    new Tire {Pressure = double.Parse(command[9]), Age = int.Parse(command[10])},
                    new Tire {Pressure = double.Parse(command[11]), Age = int.Parse(command[12])}
                };

                Car car = new(model, engine, cargo, tires);
                cars.Add(car);
            }

            string filter = Console.ReadLine();

            if (filter == "fragile")
            {
                cars.Where(c =>
                {
                    return c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1);
                }).Select(c => c.Model).ToList().ForEach(Console.WriteLine);
            }
            else
            {
                cars.Where(c =>
                {
                    return c.Cargo.Type == "flammable" && c.Engine.Power > 250;
                }).Select(c => c.Model).ToList().ForEach(Console.WriteLine);
            }
        }
    }
}