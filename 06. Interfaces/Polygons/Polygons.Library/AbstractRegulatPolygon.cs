namespace Polygons.Library;

public abstract class AbstractRegulatPolygon
{
    public int NumberOfSides { get; set; }
    public int SideLength { get; set; }

    public AbstractRegulatPolygon(int sides, int length)
    {
        NumberOfSides = sides;
        SideLength = length;
    }

    public double GetPerimeter()
    {
        return NumberOfSides * SideLength;
    }
    public abstract double GetArea();
}
