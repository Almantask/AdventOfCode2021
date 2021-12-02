using AdventOfCode.Common;

namespace AdventOfCode.Day1
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 1;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            var measures = input.ToNumbersSplitByEndOfLine();
            var increasesCount = DepthAnalyzer.CountIncreases(measures);

            return increasesCount;
        }
    }

    public class Part2 : IPartSolution
    {
        public long Solve(string input)
        {
            var measures = input.ToNumbersSplitByEndOfLine();
            var increasesCount = DepthAnalyzer.Count3WindowIncreases(measures);

            return increasesCount;
        }
    }
}
