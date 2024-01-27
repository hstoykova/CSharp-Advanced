namespace CarManufacturer
{

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new();
            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make} {Environment.NewLine}Model: {car.Model} {Environment.NewLine}Year: {car.Year}");
        }
    }
}
