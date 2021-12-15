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

        private static DisplayExperiment[] ParseExperiments(string input)
        {
            return input
                .SplitByEndOfLine()
                .Select(line => DisplayExperiment.Parse(line))
                .ToArray();
        }

        private int CountNeededDigits(DisplayExperiment[] experiments)
        {
            var neededDisplayDigitsCount = 0;
            foreach (var experiment in experiments)
            {
                // Each experiment has 4 output digits, each needs to be checked.
                const int outputDigitsCount = 4;
                for (int experimentIndex = 0; experimentIndex < outputDigitsCount; experimentIndex++)
                {
                    if (IsNeededDisplayDigit(experiment, experimentIndex))
                    {
                        neededDisplayDigitsCount++;
                    }
                }
            }

            return neededDisplayDigitsCount;
        }

        private static bool IsNeededDisplayDigit(DisplayExperiment experiment, int experimentIndex)
        {
            var segmentsOfOutputDigit = experiment.GetDigitOutput(experimentIndex);
            var isNeededDigit = _neededDisplayDigits.Any(d => d.IsGuaranteedToBeMadeFromRandomSegments(segmentsOfOutputDigit));
            return isNeededDigit;
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
