using System.Drawing;

namespace AdventOfCode.Day5;

public class Line
{
    public bool IsDiagonal => !((Beginning.X == End.X) ||
                              (Beginning.Y == End.Y));

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
        var startX = Math.Min(Beginning.X, End.X);
        var endX = Math.Max(Beginning.X, End.X);
        var startY = Math.Min(Beginning.Y, End.Y);
        var endY = Math.Max(Beginning.Y, End.Y);

        for (var x = startX; x <= endX; x++)
        {
            for (var y = startY; y <= endY; y++)
            {
                var point = new Point(x, y);
                pointsInBetween.Add(point);
            }
        }

        return pointsInBetween.ToArray();
    }
}