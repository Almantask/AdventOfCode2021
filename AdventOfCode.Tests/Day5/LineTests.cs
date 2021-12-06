using System.Drawing;
using AdventOfCode.Day5;

namespace AdventOfCode.Tests.Day5
{
    public class LineTests
    {
        [Theory]
        [MemberData(nameof(ToPointsExpectations))]
        public void ToPoints_ReturnsPointsBetweenLineEnds(Point beginning, Point end, Point[] pointsInBetween)
        {
            var line = new Line(beginning, end);

            var points = line.ToPoints();

            points.Should().BeEquivalentTo(pointsInBetween);
        }

        public static IEnumerable<object[]> ToPointsExpectations
        {
            get
            {
                yield return new object[]
                {
                    new Point(0, 0),
                    new Point(0, 2),
                    new Point[] { new(0, 0), new(0, 1), new(0, 2) }
                };
                yield return new object[]
                {
                    new Point(0, 0),
                    new Point(2, 0),
                    new Point[] { new(0, 0), new(1, 0), new(2, 0) }
                };
            }
        }
    }
}
