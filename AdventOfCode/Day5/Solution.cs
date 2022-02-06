using System.Drawing;
using AdventOfCode.Common;
using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day5
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 5;
    }

    public abstract class PartSolution<TLine> : IPartSolution
    where TLine : LineV1
    {
        public long Solve(string input)
        {
            var lines = input
                .SplitByEndOfLine()
                .Select(line => line.Split(" -> "))
                .Select(
                    pointsInLineString => CreateLine(
                        ToPoint(pointsInLineString[0]),
                        ToPoint(pointsInLineString[1]))
                ).ToArray();
            var map = new VentsMap(lines);

            var overlapsOver2Count = map
                .FindOverlaps()
                .To1D()
                .Count(overlap => overlap >= 2);

            return overlapsOver2Count;
        }

        private static Point ToPoint(string commaSeparatedCoordinates)
        {
            var parts = commaSeparatedCoordinates.Split(',');
            var x = int.Parse(parts[0]);
            var y = int.Parse(parts[1]);

            return new Point(x, y);
        }

        protected abstract TLine CreateLine(Point point1, Point point2);
    }

    public class Part1 : PartSolution<LineV1>
    {
        protected override LineV1 CreateLine(Point point1, Point point2) => new(point1, point2);
    }

    public class Part2 : PartSolution<LineV2>
    {
        protected override LineV2 CreateLine(Point point1, Point point2) => new(point1, point2);
    }
}
