using AdventOfCode.Common;
using AdventOfCode.Tests.Day6;

namespace AdventOfCode.Day6
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 6;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            var internalTimers = input
                .Split(',')
                .Select(n => int.Parse(n))
                .ToArray();

            var lanternFishes = new Lanternfishes(internalTimers);

            const int daysToSimulate = 80;
            for (var i = 0; i < daysToSimulate; i++)
            {
                lanternFishes.SimulateOneDay();
            }

            return lanternFishes.Count;
        }
    }

    public class Part2 : IPartSolution
    {
        public long Solve(string input)
        {
            var internalTimers = input
                .Split(',')
                .Select(n => int.Parse(n))
                .ToArray();

            var lanternFishes = new Lanternfishes(internalTimers);

            //const int daysToSimulate = 256;
            //for (var i = 0; i < daysToSimulate; i++)
            //{
            //    lanternFishes.SimulateOneDay();
            //}

            return lanternFishes.Count;
        }
    }
}
