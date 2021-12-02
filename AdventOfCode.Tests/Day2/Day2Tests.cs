using AdventOfCode.Day2;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Day2
{
    public class Day2Tests
    {
        [Theory]
        [MemberData(nameof(Day1Part1ExpectedDestinations))]
        public void Part1_Solve_Returns_DepthMultipliedByHorizon(string measures, long expectedDestination)
        {
            var part1 = new Part1();

            var destination = part1.Solve(measures);

            destination.Should().Be(expectedDestination);
        }

        [Theory]
        [MemberData(nameof(Day1Part2ExpectedDestinations))]
        public void Part2_Solve_WhenExampleMeasurements_ReturnsExampleIncreasesCount(string input, long expectedMeasureDestination)
        {
            var part1 = new Part2();

            var destination = part1.Solve(input);

            destination.Should().Be(expectedMeasureDestination);
        }

        public static IEnumerable<object[]> Day1Part1ExpectedDestinations
        {
            get
            {
                yield return Expect(day: 2, file: "Example", result: 150);
            }
        }

        public static IEnumerable<object[]> Day1Part2ExpectedDestinations
        {
            get
            {
                yield return Expect(day: 2, file: "Example", result: 0);
            }
        }
    }
}
