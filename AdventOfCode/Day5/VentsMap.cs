using System.Drawing;

namespace AdventOfCode.Day5;

public class VentsMap
{
    private readonly Line[] _lines;

    public VentsMap(params Line[] lines)
    {
        _lines = lines;
    }

    public int[,] FindOverlaps()
    {
        var allPoints = GetPointsAtLineEnds();
        var ventsMaps = InitializeMap(allPoints);
        AssignOverlaps(ventsMaps);

        return ventsMaps;
    }

    private Point[] GetPointsAtLineEnds()
    {
        return _lines
            .Select(line => line.Beginning)
            .Union(_lines.Select(line => line.End), AlwaysFalse.Instance)
            .ToArray();
    }

    private class AlwaysFalse : IEqualityComparer<Point>
    {
        public static AlwaysFalse Instance { get; } = new();

        public bool Equals(Point x, Point y) => false;

        public int GetHashCode(Point obj) => obj.GetHashCode();
    }

    private void AssignOverlaps(int[,] map)
    {
        var pointsInLines = _lines
            .Where(line => !line.IsDiagonal)
            .Select(line => line.ToPoints())
            .SelectMany(linePoints => linePoints);

        foreach (var point in pointsInLines)
        {
            map[point.X, point.Y]++;
        }
    }

    private static int[,] InitializeMap(Point[] allPoints)
    {
        var maxX = allPoints
            .Select(point => point.X)
            .Max();

        var maxY = allPoints
            .Select(point => point.Y)
            .Max();

        return new int[maxX + 1, maxY + 1];
    }
}