using AdventOfCode.Common;

namespace AdventOfCode.Day8
{
    public class DisplayExperimentV1 : DisplayExperiment
    {
        private DisplayExperimentV1(string[] tenSignalPatterns, string[] fourDigitsOutput) : base(tenSignalPatterns, fourDigitsOutput)
        {
        }

        public int FindDigitOne() => DigitsOutput.IndexOf(e => e.Length == 2);
        public int FindDigitFour() => DigitsOutput.IndexOf(e => e.Length == 4);
        public int FindDigitSeven() => DigitsOutput.IndexOf(e => e.Length == 3);
        public int FindDigitEight() => DigitsOutput.IndexOf(e => e.Length == 7);

        public static DisplayExperimentV1 Parse(string experimentText)
        {
            var (tenSignalPatterns, fourDigitsOutput) = ParseParts(experimentText);
            return new DisplayExperimentV1(tenSignalPatterns, fourDigitsOutput);
        }
    }
}
