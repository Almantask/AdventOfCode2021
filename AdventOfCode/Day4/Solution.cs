using AdventOfCode.Common;

namespace AdventOfCode.Day4
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
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

            return winnersScore.Value;
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

            return winnersScore.Value;
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
