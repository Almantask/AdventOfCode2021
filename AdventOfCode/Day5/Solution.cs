using System.Drawing;
using AdventOfCode.Common;

namespace AdventOfCode.Day5
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 5;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            var lines = input
                .SplitByEndOfLine()
                .Select(line => line.Split(" -> "))
                .Select(
                    pointsInLineString => new Line(
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
    }

    public class Part2 : IPartSolution
    {
        public long Solve(string input)
        {
            return 0;
        }
    }

    internal static class PartInputTransformer
    {

    }
}
