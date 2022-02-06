using AdventOfCode.Common;
using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day4
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        public const int NoWinnerScore = -1;

        protected override int Day => 4;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            var (tables, draws) = PartInputTransformer.ExtractBingoComponents(input);
            var bingo = new Bingo(tables, draws);
            bingo.Play();
            var winnersScore = bingo.GetWinnersScore();

            return winnersScore ?? Solution.NoWinnerScore;
        }
    }

    public class Part2 : IPartSolution
    {
        public long Solve(string input)
        {
            var (tables, draws) = PartInputTransformer.ExtractBingoComponents(input);
            var bingo = new RiggedBingo(tables, draws);
            bingo.Play();
            var winnersScore = bingo.GetWinnersScore();

            return winnersScore ?? Solution.NoWinnerScore;
        }
    }

    internal static class PartInputTransformer
    {
        public static (Table[], byte[]) ExtractBingoComponents(string input)
        {
            var lines = input.SplitByDoubleEndOfLine();

            var draws = lines
                .First()
                .Split(',')
                .Select(number => byte.Parse(number))
                .ToArray();

            var tables = lines
                .Skip(1)
                .Select(tableLines => Table.Parse(tableLines))
                .ToArray();

            return (tables, draws);
        }
    }
}
