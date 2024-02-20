namespace Solution01
{
    //01. Chicken Snack
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> money = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> food = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int foodCount = 0;

            while (money.Any() && food.Any())
            {
                int moneyValue = money.Pop();
                int foodPrice = food.Dequeue();
                
                if (moneyValue > foodPrice)
                {
                    foodCount++;
                    int change = moneyValue - foodPrice;

                    if (money.Any())
                    {
                        money.Push(money.Pop() + change);
                    }
                    else
                    {
                        money.Push(change);
                    }
                }
                if (moneyValue == foodPrice)
                {
                    foodCount++;
                }
            }

            if (foodCount >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {foodCount} foods.");
            }
            if (foodCount > 1 && foodCount < 4)
            {
                Console.WriteLine($"Henry ate: {foodCount} foods.");
            }
            if (foodCount == 1)
            {
                Console.WriteLine($"Henry ate: {foodCount} food.");
            }
            if (foodCount == 0)
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}