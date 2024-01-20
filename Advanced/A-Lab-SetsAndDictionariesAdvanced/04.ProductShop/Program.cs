namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, float>> shops = new ();
            string input = Console.ReadLine();
          
            while (input != "Revision")
            {
                string[] splitted = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = splitted[0];
                string product = splitted[1];
                float price = float.Parse(splitted[2]);

                if (shops.ContainsKey(shop))
                {
                    shops[shop].Add(product, price);
                }
                else
                {
                    shops.Add(shop, new Dictionary<string, float> { { product, price } } );
                }

                input = Console.ReadLine();
            }

            foreach (var shop in shops.OrderBy(s=>s.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}