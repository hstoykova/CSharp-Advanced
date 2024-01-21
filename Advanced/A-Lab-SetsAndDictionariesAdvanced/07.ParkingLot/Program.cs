namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> cars = new HashSet<string>();

            while (input != "END")
            {
                string[] splitted = input.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string command = splitted[0];
                string carNumber = splitted[1];
                if (command == "IN")
                {
                    cars.Add(carNumber);
                }
                else
                {
                    cars.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var number in cars)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}