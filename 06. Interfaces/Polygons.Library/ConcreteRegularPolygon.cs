namespace Polygons.Library;
public class ConcreteRegularPolygon
{
    public int NumberOfSides { get; set; }
    // public int SideLength { get; set; }
    private int sideLength;
    public int SideLength
    {
        get { return sideLength; }
        set { sideLength = value; }
    }
    

    public ConcreteRegularPolygon(int sides, int length)
    {
        NumberOfSides = sides;
        SideLength = length;
    }
    public double GetPerimeter()
    {
        return NumberOfSides * SideLength;
    }
    public virtual double GetArea()
    {
        throw new NotImplementedException();
    }
}