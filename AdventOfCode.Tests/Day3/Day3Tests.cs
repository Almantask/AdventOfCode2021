﻿using AdventOfCode.Day3;

namespace AdventOfCode.Tests.Day3
{
    public class Day3Tests
    {
        [Theory]
        [MemberData(nameof(Part1))]
        public void Part1_Solve_Returns(string measures, long expected)
        {
            var part1 = new Part1();

            var destination = part1.Solve(measures);

            destination.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Part2))]
        public void Part2_Solve_Returns(string input, long expected)
        {
            var part2 = new Part2();

            var destination = part2.Solve(input);

            destination.Should().Be(expected);
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
