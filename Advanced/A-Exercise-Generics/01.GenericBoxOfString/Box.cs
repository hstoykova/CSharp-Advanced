﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenericBoxOfString;

public class Box<T>
{
    private List<T> items;

    public Box()
    {
        items = new List<T>();
    }

    public void Add(T item)
    {
        items.Add(item);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (T item in items)
        {
            sb.AppendLine($"{typeof(T)}: {item.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }
}
