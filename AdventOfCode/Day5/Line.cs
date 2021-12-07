using System.Drawing;

namespace AdventOfCode.Day5;

public class LineV2 : LineV1
{
    public LineV2(Point beginning, Point end) : base(beginning, end)
    {
    }

    public override Point[] ToPoints()
    {
        if (Is45DegreesDiagonal())
        {
            return ToPointsAlongsideDiagonal();
        }
        else
        {
            return base.ToPoints();
        }
    }

    public override bool IsValid()
    {
        return !IsDiagonal || Is45DegreesDiagonal();
    }

    private bool Is45DegreesDiagonal()
    {
        const double epsilon = 0.01;
        return Math.Abs(
                        Math.Abs(Beginning.X - End.X) -
                        Math.Abs(Beginning.Y - End.Y)
                    ) < epsilon;
    }

    private Point[] ToPointsAlongsideDiagonal()
    {
        var pointsInBetween = new List<Point>();

        var xDelta = Beginning.X < End.X ? 1 : -1;
        var yDelta = Beginning.Y < End.Y ? 1 : -1;

        var x = Beginning.X;
        var distance = Math.Abs(Beginning.X - End.X);
        var y = Beginning.Y;

        while (distance >= 0)
        {
            var point = new Point(x, y);
            pointsInBetween.Add(point);
            x += xDelta;
            y += yDelta;
            distance--;
        }

        return pointsInBetween.ToArray();
    }
}


public class LineV1
{
    public virtual bool IsValid() => !IsDiagonal;

    public bool IsDiagonal => !((Beginning.X == End.X) ||
                                (Beginning.Y == End.Y));

    public Point Beginning { get; }
    public Point End { get; }

    public LineV1(Point beginning, Point end)
    {
        Beginning = beginning;
        End = end;
    }

    public virtual Point[] ToPoints()
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