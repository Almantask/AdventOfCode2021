using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Common;
using AdventOfCode.Day5;

namespace AdventOfCode.Tests.Day5
{
    public class VentsMapTests
    {
        [Theory]
        [MemberData(nameof(ExpectedOverlaps))]
        public void FindOverlaps_ReturnsOverlapsArrayWithCountsOfOverlapsAtPoint(VentsMap ventsMap, int[,] expectedOverlap)
        {
            var overlaps = ventsMap.FindOverlaps();

            overlaps.Should().BeEquivalentTo(expectedOverlap);
        }

        public static IEnumerable<object[]> ExpectedOverlaps
        {
            get
            {
                var line = new Line(new Point(0, 0), new Point(0, 2));
                var ventsMapWith1IdenticalLine = new VentsMap(line);
                yield return new object[]
                {
                    ventsMapWith1IdenticalLine,
                    new[,]
                    {
                        { 0, 0, 0 }
                    }
                };

                var ventsMapWith2IdenticalLine = new VentsMap(line, line);
                yield return new object[]
                {
                    ventsMapWith2IdenticalLine,
                    new[,]
                    {
                        { 1, 1, 1 }
                    }
                };

                var ventsMapWith3IdenticalLine = new VentsMap(line, line, line);
                yield return new object[]
                {
                    ventsMapWith3IdenticalLine,
                    new[,]
                    {
                        { 2, 2, 2 }
                    }
                };

                var point1 = new Point(0, 0);
                var point2 = new Point(0, 2);
                var point3 = new Point(0, 4);
                var point4 = new Point(2, 4);
                var point5 = new Point(2, 2);
                var point6 = new Point(2, 3);
                var line1 = new Line(point1, point2);
                var line2 = new Line(point2, point3);
                var line3 = new Line(point3, point4);
                var line4 = new Line(point2, point5);
                var line5 = new Line(point5, point6);
                var ventsMapWith3Overlaps = new VentsMap(line1, line2, line3, line4, line5);

                yield return new object[]
                {
                    ventsMapWith3Overlaps,
                    new[,]
                    {
                        { 0, 0, 2, 0, 1 },
                        { 0, 0, 0, 0, 0 },
                        { 0, 0, 1, 0, 0 }
                    }
                };

                // Ignore diagonal lines.
                // Include a test case for that.
            }
        }
    }
}
