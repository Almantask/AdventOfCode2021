using AdventOfCode.Day8;

namespace AdventOfCode.Tests.Day8
{
    public class Day8Tests
    {
        [Theory]
        [MemberData(nameof(Part1))]
        public void Part1_Solve_Returns(string measures, long expected)
        {
            var part1 = new Part1();

            var actual = part1.Solve(measures);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Part2))]
        public void Part2_Solve_Returns(string input, long expected)
        {
            var part2 = new Part2();

            var actual = part2.Solve(input);

            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> Part1
        {
            get
            {
                yield return Expect(day: 8, file: "Example", result: 26);
            }
        }

        public static IEnumerable<object[]> Part2
        {
            get
            {
                yield return Expect(day: 8, file: "Example", result: 61229);
            }
        }
    }
}
