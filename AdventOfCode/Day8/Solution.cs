using AdventOfCode.Common;

namespace AdventOfCode.Day8
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 8;
    }

    public class Part1 : IPartSolution
    {
        private static readonly DisplayDigit[] _neededDisplayDigits =
        {
            DisplayDigit.Create(1),
            DisplayDigit.Create(4),
            DisplayDigit.Create(7),
            DisplayDigit.Create(8)
        };

        public long Solve(string input)
        {
            var experiments = ParseExperiments(input);
            var neededDigitsCount = CountNeededDigits(experiments);

            return neededDigitsCount;
        }

        private static DisplayExperimentV1[] ParseExperiments(string input)
        {
            return input
                .SplitByEndOfLine()
                .Select(line => DisplayExperimentV1.Parse(line))
                .ToArray();
        }

        private int CountNeededDigits(DisplayExperimentV1[] experiments)
        {
            var neededDisplayDigitsCount = 0;
            foreach (var experiment in experiments)
            {
                // Each experiment has 4 output digits, each needs to be checked.
                const int outputDigitsCount = 4;
                var indexOf1 = experiment.Find1();
                var one = GetMixed(experiment, indexOf1);
                var indexOf4 = experiment.Find4();
                var four = GetMixed(experiment, indexOf4);
                var indexOf7 = experiment.Find7();
                var seven = GetMixed(experiment, indexOf7);
                var indexOf8 = experiment.Find8();
                var eight = GetMixed(experiment, indexOf8);

                for (int outputDigitIndex = 0; outputDigitIndex < outputDigitsCount; outputDigitIndex++)
                {
                    var outputDigit = experiment.GetDigitOutput(outputDigitIndex);
                    var isNeededDisplayDigit = outputDigit.IsEquivalentTo(one) ||
                                               outputDigit.IsEquivalentTo(four) ||
                                               outputDigit.IsEquivalentTo(seven) ||
                                               outputDigit.IsEquivalentTo(eight);
                    if (isNeededDisplayDigit)
                    {
                        neededDisplayDigitsCount++;
                    }
                }
            }

            return neededDisplayDigitsCount;

            char[] GetMixed(DisplayExperiment experiment, int outputIndex)
            {
                const int notFound = -1;
                if (outputIndex == notFound) return Array.Empty<char>();
                return experiment.GetDigitOutput(outputIndex);
            }
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
