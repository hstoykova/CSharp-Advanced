namespace GroceriesManagement;

public class Product
{
	private string name;
    private double price;

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public string Name
	{
		get { return name; }
		set { name = value; }
	}

	public double Price
	{
		get { return price; }
		set { price = value; }
	}

    public override string ToString()
    {
        return $"{Name}: {Price:F2}$";
    }
}
