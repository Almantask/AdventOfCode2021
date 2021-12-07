using System.Drawing;
using AdventOfCode.Day5;

namespace AdventOfCode.Tests.Day5
{
    public class VentsMapTests
    {
        [Theory]
        [MemberData(nameof(ExpectedOverlaps))]
        public void FindOverlaps_ReturnsOverlapsArrayWithCountsLinesAtPoint(VentsMap ventsMap, int[,] expectedOverlap)
        {
            var overlaps = ventsMap.FindOverlaps();

            overlaps.Should().BeEquivalentTo(expectedOverlap);
        }

        public static IEnumerable<object[]> ExpectedOverlaps
        {
            get
            {
                var line = new Line(new Point(0, 0), new Point(0, 2));
                var singleLine = new VentsMap(line);
                yield return new object[]
                {
                    singleLine,
                    new[,]
                    {
                        { 1, 1, 1 }
                    }
                };

                var identicalLines2 = new VentsMap(line, line);
                yield return new object[]
                {
                    identicalLines2,
                    new[,]
                    {
                        { 2, 2, 2 }
                    }
                };

                var point1 = new Point(0, 0);
                var point2 = new Point(0, 2);
                var point3 = new Point(0, 4);
                var point4 = new Point(2, 4);
                var line1 = new Line(point1, point2);
                var line2 = new Line(point2, point3);
                var line3 = new Line(point3, point4);
                var Overlaps3 = new VentsMap(line1, line2, line3);

                yield return new object[]
                {
                    Overlaps3,
                    new[,]
                    {
                        { 1, 1, 2, 1, 2 },
                        { 0, 0, 0, 0, 1 },
                        { 0, 0, 0, 0, 1 }
                    }
                };

                var diagonalLine = new Line(new Point(0, 0), new Point(1, 3));
                var diagonalLineIgnored = new VentsMap(diagonalLine, diagonalLine);
                yield return new object[]
                {
                    diagonalLineIgnored,
                    new[,]
                    {
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }
                    }
                };
            }
        }
    }
}
