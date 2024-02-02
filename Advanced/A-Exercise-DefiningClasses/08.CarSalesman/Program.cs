namespace _08.CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] prop = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = prop[0];
                int power = int.Parse(prop[1]);
                Engine engine = new Engine(model, power);

                if (prop.Length > 2)
                {
                    if (int.TryParse(prop[2], out _))
                    {
                        engine.Displacement = int.Parse(prop[2]);
                    }
                    else
                    {
                        engine.Efficiency = prop[2];
                        engines.Add(engine);
                        continue;
                    }
                }

                if (prop.Length > 3)
                {
                    engine.Efficiency = prop[3];
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] prop = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = prop[0];
                Engine engine = engines.Find(engine => engine.Model == prop[1]);
                Car car = new Car(model, engine);


                if (prop.Length > 2)
                {
                    if (int.TryParse(prop[2], out _))
                    {
                        car.Weight = int.Parse(prop[2]);
                    }
                    else
                    {
                        car.Color = prop[2];
                        cars.Add(car);
                        continue;
                    }

                }

                if (prop.Length > 3)
                {
                    car.Color = prop[3];
                }

                cars.Add(car);
            }

            cars.ForEach(Console.Write);
        }
    }
}