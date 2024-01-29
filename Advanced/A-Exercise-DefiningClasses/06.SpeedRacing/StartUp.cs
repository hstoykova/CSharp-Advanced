namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInformation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new (carInformation[0], double.Parse(carInformation[1]), double.Parse(carInformation[2]));

                cars.Add(car);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] parts = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car currentCar = cars.Find(c => c.Model == parts[1]);

                if (currentCar.CanTravelTheDistance(int.Parse(parts[2])))
                {
                    currentCar.FuelAmount -= int.Parse(parts[2]) * currentCar.FuelConsumptionPerKilometer;
                    currentCar.TravelledDistance += int.Parse(parts[2]);
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (var c in cars)
            {
                Console.WriteLine($"{c.Model} {c.FuelAmount:F2} {c.TravelledDistance}");
            }
        }
    }
}