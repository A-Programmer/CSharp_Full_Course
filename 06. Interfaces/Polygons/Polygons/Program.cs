using Polygons.Library;

namespace Polygons;

class Program
{
    static void Main(string[] args)
    {
        Square square = new(5);
        DisplayPolygon("Square", square);

        Triangle triangle = new(5);
        DisplayPolygon("Triangle", triangle);

        Octagon octagon = new(5);
        DisplayPolygon("Octagon", octagon);

        Console.ReadLine();
    }

    public static void DisplayPolygon(string polygonType, dynamic polygon)
    {
        Console.WriteLine(polygonType);
        switch(polygonType)
        {
            case "Square":
            {
                Square square = (Square)polygon;
                PrintDetails(square.NumberOfSides, square.SideLength, square.GetPerimeter(), square.GetArea());
                break;
            }
            case "Triangle":
            {
                Triangle triangle = (Triangle)polygon;
                PrintDetails(triangle.NumberOfSides, triangle.SideLength, triangle.GetPerimeter(), triangle.GetArea());
                break;
            }
            case "Octagon":
            {
                Octagon octagon = (Octagon)polygon;
                PrintDetails(octagon.NumberOfSides, octagon.SideLength, octagon.GetPerimeter(), octagon.GetArea());
                break;
            }
            default:
            {
                throw new Exception("No polygon found.");
            }
        }
    }

    private static void PrintDetails(int sides, int length, double perimeter, double area)
    {
        Console.WriteLine($"Number of Sides: {sides}");
        Console.WriteLine($"Side Length: {length}");
        Console.WriteLine($"Perimeter: {perimeter}");
        Console.WriteLine($"Area: {area}");
        Console.WriteLine("\n=====================\n");
    }
}