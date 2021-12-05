using AdventOfCode.Day3;

namespace AdventOfCode.Tests.Day3
{
    public class Day3Tests
    {
        [Theory]
        [MemberData(nameof(Part1))]
        public void Part1_Solve_ReturnsPowerConsumptionRate(string measures, long expectedPowerConsumptionRate)
        {
            var part1 = new Part1();

            var powerConsumptionRate = part1.Solve(measures);

            powerConsumptionRate.Should().Be(expectedPowerConsumptionRate);
        }

        [Theory]
        [MemberData(nameof(Part2))]
        public void Part2_Solve_ReturnsLifeSupportRate(string input, long expectedLifeSupportRate)
        {
            var part2 = new Part2();

            var lifeSupportRate = part2.Solve(input);

            lifeSupportRate.Should().Be(expectedLifeSupportRate);
        }

        public static IEnumerable<object[]> Part1
        {
            get
            {
                yield return Expect(day: 3, file: "Example", result: 198);
            }
        }

        public static IEnumerable<object[]> Part2
        {
            get
            {
                yield return Expect(day: 3, file: "Example", result: 230);
            }
        }
    }
}
