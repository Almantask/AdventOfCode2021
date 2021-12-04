using AdventOfCode.Common;

namespace AdventOfCode.Day3
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 3;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            var binaryNumbers = input
                .SplitByEndOfLine()
                .Select(binary => binary.ToCharArray())
                .ToArray()
                .To2D();

            var diagnosticReport = new DiagnosticReport(binaryNumbers);
            return diagnosticReport.PowerConsumption;
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
