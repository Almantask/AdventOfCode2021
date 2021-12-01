using AdventOfCode.Day1;
using FluentAssertions;
using Xunit;
using static AdventOfCode.Tests.Common.ExpectationMaker;

namespace AdventOfCode.Tests.Day1
{
    public class Day1Tests
    {
        private const int Day = 1;

        [Theory]
        [MemberData(nameof(Part1ExpectedMeasureIncreases))]
        public void Part1_Solve_ReturnsIncreasesCount(string measures, long expectedMeasureIncreases)
        {
            var part1 = new Part1();

            var measureIncreases = part1.Solve(measures);

            measureIncreases.Should().Be(expectedMeasureIncreases);
        }

        [Theory]
        [MemberData(nameof(Part2ExpectedMeasureIncreases))]
        public void Part2_Solve_WhenExampleMeasurements_ReturnsExampleIncreasesCount(string input, long expectedMeasureIncreases)
        {

        }

        public static IEnumerable<object[]> Part1ExpectedMeasureIncreases
        {
            get
            {
                yield return Expect(Day, "Example", 7);
            }
        }

        public static IEnumerable<object[]> Part2ExpectedMeasureIncreases
        {
            get
            {
                yield return Expect(Day, "Example", 7);
            }
        }
    }
}
