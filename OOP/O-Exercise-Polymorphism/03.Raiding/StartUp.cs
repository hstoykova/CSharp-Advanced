﻿using Heroes.Models;
using System;

namespace Heroes;

public class StartUp
{
    static void Main(string[] args)
    {
        List<BaseHero> list = new();

        int heroCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < heroCount; i++)
        {
            string heroName = Console.ReadLine();
            string heroType = Console.ReadLine();

            if (heroType == "Druid")
            {
                list.Add(new Druid(heroName));
            }
            else if (heroType == "Paladin")
            {
                list.Add(new Paladin(heroName));
            }
            else if (heroType == "Rogue")
            {
                list.Add(new Rogue(heroName));
            }
            else if (heroType == "Warrior")
            {
                list.Add(new Warrior(heroName));
            }
            else
            {
                Console.WriteLine("Invalid hero!");
                i--;
            }

        }

       
        

        foreach (var hero in list)
        {
            Console.WriteLine($"{hero.CastAbility()}");
        }

        int result = list.Sum(h => h.Power);
        int bossPower = int.Parse(Console.ReadLine());

        Console.WriteLine(result >= bossPower ? "Victory!" : "Defeat...");
    }
}