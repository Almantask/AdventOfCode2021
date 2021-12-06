using System.Drawing;

namespace AdventOfCode.Day5;

public class Line
{
    public Point Beginning { get; }
    public Point End { get; }

    public Line(Point beginning, Point end)
    {
        Beginning = beginning;
        End = end;
    }

    public Point[] ToPoints()
    {
        var pointsInBetween = new List<Point>();
        for (var x = Beginning.X; x <= End.X; x++)
        {
            for (var y = Beginning.Y; y <= End.Y; y++)
            {
                var point = new Point(x, y);
                pointsInBetween.Add(point);
            }
        }

        return pointsInBetween.ToArray();
    }
}