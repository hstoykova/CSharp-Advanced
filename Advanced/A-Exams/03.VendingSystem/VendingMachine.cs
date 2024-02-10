using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem;

public class VendingMachine
{
    public VendingMachine(int buttonCapacity)
    {
        ButtonCapacity = buttonCapacity;
        Drinks = new List<Drink>();
    }

    public int ButtonCapacity { get; set; }

    public List<Drink> Drinks { get; set; }

    public int GetCount
    {
        get
        {
            return Drinks.Count;
        }
    }

    public void AddDrink(Drink drink)
    {
        if (ButtonCapacity > GetCount)
        {
            Drinks.Add(drink);
        }
    }

    public bool RemoveDrink(string name)
    {
        int index = Drinks.FindIndex(x => x.Name == name);

        if (index == -1)
        {
            return false;
        }
        else
        {
            Drinks.RemoveAt(index);
            return true;
        }
    }

    public Drink GetLongest()
    {
        return Drinks.OrderByDescending(d => d.Volume).First();
    }

    public Drink GetCheapest()
    {
        return Drinks.OrderBy(d => d.Price).First();
    }

    public string BuyDrink(string name)
    {
        return Drinks.Find(x => x.Name == name).ToString();
    }

    public string Report()
    {
        StringBuilder sb = new();
        sb.AppendLine("Drinks available:");
        Drinks.ForEach(d => sb.AppendLine(d.ToString()));
        return sb.ToString().Trim();
    }
}
