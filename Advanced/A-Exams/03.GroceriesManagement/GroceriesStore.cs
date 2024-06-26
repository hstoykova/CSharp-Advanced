﻿using System.Text;
using System.Xml.Linq;

namespace GroceriesManagement;

public class GroceriesStore
{
	private int capacity;
    private double turnover;
    private List<Product> stall;

    public GroceriesStore(int capacity)
    {
        Capacity = capacity;
		Turnover = 0;
		Stall = new();
    }

    public int Capacity
	{
		get { return capacity; }
		set { capacity = value; }
	}

	public double Turnover
    {
		get { return turnover; }
		set { turnover = value; }
	}

	public List<Product> Stall
	{
		get { return stall; }
		set { stall = value; }
	}

	public void AddProduct(Product product)
	{
		if (Capacity > Stall.Count)
		{
			if (!Stall.Contains(product))
			{
                Stall.Add(product);
            }
        }
	}

	public bool RemoveProduct(string name)
	{
		int productIndex = Stall.FindIndex(x => x.Name == name);

		if (productIndex < 0)
		{
			return false;
		}
		else
		{
			Stall.RemoveAt(productIndex);
            return true;
		}
	}

	public string SellProduct(string name, double quantity)
	{
		Product product = Stall.Find(p => p.Name == name);

		if (product is null)
		{
			return "Product not found";
        }

        Turnover += Math.Round((product.Price * quantity), 2);

        return $"{name} - {product.Price * quantity:F2}$";
    }

	public string GetMostExpensive()
	{
        Product product = Stall.OrderByDescending(p => p.Price).First();
		return product.ToString();
    }

	public string CashReport()
	{
		return $"Total Turnover: {Turnover:F2}$";
    }

	public string PriceList()
    {
		StringBuilder sb = new();
		sb.AppendLine("Groceries Price List:");

		foreach (var product in Stall)
		{
			sb.AppendLine(product.ToString());
		}
		
		return sb.ToString().TrimEnd();
    }

}
