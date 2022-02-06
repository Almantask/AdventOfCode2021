using AdventOfCode.Common;
using AdventOfCode.Common.Day;

namespace AdventOfCode.Day7
{
    public class Solution : AdventOfCodeAdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 7;
    }

    public class Part1 : ParSolution<CrabSubmarinesV1>
    {
        protected override CrabSubmarinesV1 BuildCrabSubmarines(int[] sumbarineHorizontalPositions)
            => new(sumbarineHorizontalPositions);
    }

    public class Part2 : ParSolution<CrabSubmarinesV2>
    {
        protected override CrabSubmarinesV2 BuildCrabSubmarines(int[] sumbarineHorizontalPositions)
            => new(sumbarineHorizontalPositions);
    }

    public abstract class ParSolution<TCrabSumbarines> : IPartSolution
        where TCrabSumbarines : ICrabSubmarines
    {
        public long Solve(string input)
        {
            var submarinesHorizontalPositions = input
                .Split(',')
                .Select(n => int.Parse(n))
                .ToArray();

            var crabSubmarines = BuildCrabSubmarines(submarinesHorizontalPositions);
            var optimalAlignment = crabSubmarines.GetOptimalAlignment();
            var fuelCost = crabSubmarines.CalculateFuelCostTo(optimalAlignment);

            return fuelCost;
        }

        protected abstract TCrabSumbarines BuildCrabSubmarines(int[] sumbarineHorizontalPositions);
    }
}
