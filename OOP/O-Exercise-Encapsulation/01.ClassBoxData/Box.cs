

namespace ClassBoxData;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get { return length; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            length = value;
        }
    }

    public double Width
    {
        get { return width; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
        }
    }

    public double Height
    {
        get { return height; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
        }
    }

    public double SurfaceArea(double length, double width, double heihht)
    {
        return 2 * length * width + 2 * length * heihht + 2 * width * heihht;
        // 2lw + 2lh + 2wh
    }

    public double LateralSurfaceArea(double length, double width, double heihht)
    {
        return 2 * length * heihht + 2 * width * heihht;
        //2lh + 2wh
    }

    public double Volume(double length, double width, double heihht)
    {
        return length * width * heihht;
        //lwh
    }
}


