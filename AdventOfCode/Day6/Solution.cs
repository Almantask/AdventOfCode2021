using AdventOfCode.Common;
using AdventOfCode.Common.Day;

namespace AdventOfCode.Day6
{
    public class Solution : AdventOfCodeAdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 6;
    }

    public class Part1 : PartSolution
    {
        protected override int DaysToSimulate => 80;

        protected override ILanternfishes BuildLanternFishes(int[] internalTimers)
            => new Lanternfishes.Naive(internalTimers);
    }

    public class Part2 : PartSolution
    {
        protected override int DaysToSimulate => 256;

        protected override ILanternfishes BuildLanternFishes(int[] internalTimers)
            => new Lanternfishes.Optimal(internalTimers);
    }

    public abstract class PartSolution : IPartSolution
    {
        protected abstract int DaysToSimulate { get; }

        public long Solve(string input)
        {
            var internalTimers = input
                .Split(',')
                .Select(n => int.Parse(n))
                .ToArray();

            var lanternFishes = BuildLanternFishes(internalTimers);

            for (var i = 0; i < DaysToSimulate; i++)
            {
                lanternFishes.SimulateOneDay();
            }

            return lanternFishes.Count;
        }

        protected abstract ILanternfishes BuildLanternFishes(int[] internalTimers);
    }
}
