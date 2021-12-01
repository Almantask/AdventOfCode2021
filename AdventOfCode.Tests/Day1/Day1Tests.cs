using AdventOfCode.Day1;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Day1
{
    public class Day1Tests
    {
        private const int Day = 1;

        [Theory]
        [MemberData(nameof(Day1ExpectedMeasureIncreases))]
        public void Part1_Solve_ReturnsIncreasesCount(string measures, long expectedMeasureIncreases)
        {
            var part1 = new Part1();

            var measureIncreases = part1.Solve(measures);

            measureIncreases.Should().Be(expectedMeasureIncreases);
        }

        [Theory]
        [MemberData(nameof(Day1ExpectedMeasureIncreases))]
        public void Part2_Solve_WhenExampleMeasurements_ReturnsExampleIncreasesCount(string input, long expectedMeasureIncreases)
        {

        }

        public static IEnumerable<object[]> Day1ExpectedMeasureIncreases
        {
            get
            {
                yield return Expect(day: 1, file: "Example", result: 7);
            }
        }
    }
}
