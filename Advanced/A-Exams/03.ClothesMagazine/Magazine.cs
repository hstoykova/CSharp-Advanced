﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine;

public class Magazine
{
    public Magazine(string type, int capacity)
    {
        Type = type;
        Capacity = capacity;
        Clothes = new List<Cloth>();
    }

    public string Type { get; set; }

    public int Capacity { get; set; }

    public List<Cloth> Clothes { get; set; }

    public void AddCloth(Cloth cloth)
    {
        if (Capacity > Clothes.Count)
        {
            Clothes.Add(cloth);
        }
    }

    public bool RemoveCloth(string color)
    {
        Cloth clothes = Clothes.Find(c => c.Color == color);

        if (clothes != null)
        {
            Clothes.Remove(clothes);
            return true;
        }
        return false;
    }

    public Cloth GetSmallestCloth()
    {
        return Clothes.OrderBy(c => c.Size).First();
    }

    public Cloth GetCloth(string color)
    {
        return Clothes.Find(c => c.Color == color);
    }

    public int GetClothCount()
    {
        return Clothes.Count;
    }

    public string Report()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{Type} magazine contains:");

        foreach (Cloth cloth in Clothes.OrderBy(c => c.Size))
        {
            sb.AppendLine(cloth.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}
