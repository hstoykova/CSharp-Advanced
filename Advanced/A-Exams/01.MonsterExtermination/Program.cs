namespace _01.MonsterExtermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> monstersArmor = new Queue<int>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> soldierStrike = new Stack<int>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int killedMonsters = 0;

            while (monstersArmor.Count > 0 && soldierStrike.Count > 0)
            {
                int strike = soldierStrike.Pop();

                if (monstersArmor.Peek() <= strike)
                {
                    strike -= monstersArmor.Dequeue();
                    killedMonsters++;

                    if (strike == 0)
                    {
                        continue;
                    }

                    if (soldierStrike.Any())
                    {
                        strike += soldierStrike.Pop();
                        soldierStrike.Push(strike);
                    }
                    else
                    {
                        soldierStrike.Push(strike);
                    }
                }
                else
                {
                    int armor = monstersArmor.Dequeue();
                    armor -= strike;
                    monstersArmor.Enqueue(armor);
                }
            }

            if (!monstersArmor.Any())
            {
                Console.WriteLine("All monsters have been killed!");
            }
            if (!soldierStrike.Any())
            {
                Console.WriteLine("The soldier has been defeated.");
            }
            Console.WriteLine($"Total monsters killed: {killedMonsters}");

        }
    }
}