using AdventOfCode.Common;

namespace AdventOfCode.Day7
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 7;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            var submarinesHorizontalPositions = input
                .Split(',')
                .Select(n => int.Parse(n))
                .ToArray();

            var crabSubmarines = new CrabSubmarines(submarinesHorizontalPositions);
            var optimalAlignment = crabSubmarines.GetOptimalAlginment();
            var fuelCost = crabSubmarines.CalculateFuelCostTo(optimalAlignment);

            return fuelCost;
        }
    }

    public class Part2 : IPartSolution
    {
        public long Solve(string input)
        {
            return 0;
        }
    }
}
