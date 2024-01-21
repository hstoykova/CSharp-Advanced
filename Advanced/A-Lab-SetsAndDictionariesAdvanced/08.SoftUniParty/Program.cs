namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> reservations = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                reservations.Add(input);
            }

            while ((input = Console.ReadLine()) != "END")
            {
                reservations.Remove(input);
            }

            Console.WriteLine(reservations.Count);

            foreach (var vip in reservations)
            {
                if (vip[0] >= 48 && vip[0] <= 57)
                {
                    Console.WriteLine(vip);
                }
            }

            foreach (var notvip in reservations)
            {
                if (!(notvip[0] >= 48 && notvip[0] <= 57))
                {
                    Console.WriteLine(notvip);
                }                            
            }
        }
    }
}