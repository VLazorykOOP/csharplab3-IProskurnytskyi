// dotnet run --property:DefineConstants="RUN_POINT"
using System;

class Point
{
    protected int x, y;
    protected readonly int color;

    public Point()
    {
        this.x = 0;
        this.y = 0;
        this.color = 0;
    }

    public Point(int x, int y, int color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }

    public void PrintCoordinates()
    {
        Console.WriteLine($"Coordinates: ({this.x}, {this.y})");
    }

    public double CalculateDistanceToOrigin()
    {
        return Math.Sqrt(this.x * this.x + this.y * this.y);
    }

    public void Move(int x1, int y1)
    {
        this.x += x1;
        this.y += y1;
    }

    public int X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    public int Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    public int Color
    {
        get { return this.color; }
    }
}

class Program
{
#if RUN_POINT
    static void Main(string[] args)
    {
        Point[] points = new Point[3];
        points[0] = new Point(3, 4, 1);
        points[1] = new Point(-2, 6, 2);
        points[2] = new Point(1, -5, 3);

        double totalDistance = 0;
        foreach (Point p in points)
        {
            totalDistance += p.CalculateDistanceToOrigin();
        }
        double averageDistance = totalDistance / points.Length;

        Console.WriteLine($"Average distance to origin: {averageDistance}");
        Console.WriteLine();

        foreach (Point p in points)
        {
            p.PrintCoordinates();
            Console.WriteLine($"Distance to origin: {p.CalculateDistanceToOrigin()}");

            if (p.CalculateDistanceToOrigin() > averageDistance)
            {
                p.Move(1, 1);
                Console.WriteLine("Point moved to (x+1, y+1)");
            }

            Console.WriteLine();
        }
    }
#endif
}
