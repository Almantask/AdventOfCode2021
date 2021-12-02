using AdventOfCode.Day1;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Day1
{
    public class Day1Tests
    {
        [Theory]
        [MemberData(nameof(Day1Part1ExpectedMeasureIncreases))]
        public void Part1_Solve_(string measures, long expectedMeasureIncreases)
        {
            var part1 = new Part1();

            var measureIncreases = part1.Solve(measures);

            measureIncreases.Should().Be(expectedMeasureIncreases);
        }

        [Theory]
        [MemberData(nameof(Day1Part2ExpectedMeasureIncreases))]
        public void Part2_Solve_WhenExampleMeasurements_ReturnsExampleIncreasesCount(string input, long expectedMeasureIncreases)
        {
            var part2 = new Part2();

            var measureIncreases = part2.Solve(input);

            measureIncreases.Should().Be(expectedMeasureIncreases);
        }

        public static IEnumerable<object[]> Day1Part1ExpectedMeasureIncreases
        {
            get
            {
                yield return Expect(day: 1, file: "Example", result: 7);
            }
        }

        public static IEnumerable<object[]> Day1Part2ExpectedMeasureIncreases
        {
            get
            {
                yield return Expect(day: 1, file: "Example", result: 5);
            }
        }
    }
}
