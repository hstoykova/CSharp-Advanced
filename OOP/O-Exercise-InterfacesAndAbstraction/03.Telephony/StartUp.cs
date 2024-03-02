namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in phoneNumbers)
            {
                if (number.All(char.IsDigit))
                {
                    ICallable phone;

                    if (number.Length == 7)
                    {
                        phone = new StationaryPhone();
                    }
                    else
                    {
                        phone = new Smartphone();
                    }

                    phone.Call(number);
                }                
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var website in websites)
            {
                if (IsUrlValid(website))
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Browse(website);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }

            static bool IsUrlValid(string website)
            {
                return !website.Any(char.IsDigit);
            }
        }
    }
}