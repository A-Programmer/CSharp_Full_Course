namespace Polygons.Library;

public class Triangle : AbstractRegulatPolygon
{
    public Triangle(int length)
        : base(3, length)
    {
    }
    public override double GetArea()
    {
        return SideLength * SideLength * Math.Sqrt(3) / 4;
    }
}
