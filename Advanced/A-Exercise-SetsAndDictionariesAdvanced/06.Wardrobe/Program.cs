/*
2
Tomato -> Belt,Shirt,Cummerbund,Shirt,Cravat,Shirt,Belt
OliveDrab -> Jacket,Shoes,Overalls,Shoes,Jacket,Shoes,Shoes
OliveDrab Jacket
 */

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] splitted = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = splitted[0];
                string[] clothes = splitted[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (wardrobe.ContainsKey(color)) //дали цветът е вече добавен
                {
                    foreach (var item in clothes) //трябва да добавим всяка дреха от съответния цвят
                    {
                        if (wardrobe[color].ContainsKey(item)) //проверяваме дали вече има такава дреха от съответния цвят
                        {
                            wardrobe[color][item]++;
                        }
                        else
                        {
                            wardrobe[color].Add(item, 1);
                        }
                    }
                }
                else //ако цвета не е добавен
                {
                    Dictionary<string, int> clothesCount = new();
                    foreach (var item in clothes)
                    {
                        if (clothesCount.ContainsKey(item))
                        {
                            clothesCount[item]++;
                        } else
                        {
                            clothesCount.Add(item, 1);
                        }
                    }

                    wardrobe.Add(color, clothesCount);
                }
            }

            string[] searchedClothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string searchedColor = searchedClothes[0];
            string searchedItem = searchedClothes[1];

            foreach (var col in wardrobe)
            {
                Console.WriteLine($"{col.Key} clothes:");

                foreach (var item in col.Value)
                {
                    if (col.Key == searchedColor && item.Key == searchedItem)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}