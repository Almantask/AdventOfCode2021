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
                    new Point(0, 2),
                    new Point(0, 0),
                    new Point[] { new(0, 0), new(0, 1), new(0, 2) }
                };
                yield return new object[]
                {
                    new Point(0, 2),
                    new Point(0, 0),
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

        [Theory]
        [InlineData(0, 0, 0, 1, false)]
        [InlineData(0, 0, 1, 0, false)]
        [InlineData(0, 0, 1, 1, true)]
        [InlineData(1, 1, 0, 0, true)]
        [InlineData(1, 0, 1, 0, false)]
        [InlineData(0, 1, 0, 1, false)]
        public void IsDiagonal_ReturnsTrueWhetherXOrYMatch(int x1, int y1, int x2, int y2, bool expectedIsDiagonal)
        {
            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);
            var line = new Line(point1, point2);

            var isDiagonal = line.IsDiagonal;

            isDiagonal.Should().Be(expectedIsDiagonal);
        }
    }
}
