namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new(length, width, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea(length, width, height):F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea(length, width, height):F2}");
                Console.WriteLine($"Volume - {box.Volume(length, width, height):F2}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            

        }
    }
}