using AdventOfCode.Common;
using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;

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
            var binaryNumbers = PartInputTransformer.TransformTo2DArray(input);
            var diagnosticReport = new DiagnosticReport(binaryNumbers);
            return diagnosticReport.PowerConsumption;
        }
    }

    public class Part2 : IPartSolution
    {
        public long Solve(string input)
        {
            var binaryNumbers = PartInputTransformer.TransformTo2DArray(input);
            var diagnosticReport = new DiagnosticReportV2(binaryNumbers);
            return diagnosticReport.LifeSupportRating;
        }
    }

    internal static class PartInputTransformer
    {
        public static char[,] TransformTo2DArray(string input)
        {
            var binaryNumbers = input
                .SplitByEndOfLine()
                .Select(binary => binary.ToCharArray())
                .ToArray()
                .To2D();

            return binaryNumbers;
        }
    }
}
