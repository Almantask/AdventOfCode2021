using AdventOfCode.Common;

namespace AdventOfCode.Day8
{
    /// <summary>
    /// <para>
    /// Digit eight is always needed as an argument, because it will be used as a map for all the other digits.
    /// In other words- it is the complete 7-digit segments array.
    /// </para>
    /// <para>
    /// Finding a digit means looking for its index inside 10-signals.
    /// </para>
    /// <para>
    /// Finding a segments means looking for its index inside digit eight.
    /// </para>
    /// </summary>
    public class DisplayExperimentV2 : DisplayExperiment
    {
        private DisplayExperimentV2(string[] tenSignalPatterns, string[] fourDigitsOutput) : base(tenSignalPatterns, fourDigitsOutput)
        {
        }

        /// <summary>
        /// Digit seven compared to digit one has 1 extra segment - a.
        /// </summary>
        public int FindSegmentA(char[] seven, char[] one, char[] eight)
        {
            var segmentA = seven.Except(one).First();
            var indexOfSegmentA = eight.IndexOf(segment => segment == segmentA);
            return indexOfSegmentA;
        }

        public int FindDigitOne() => TenSignalPatterns.IndexOf(e => e.Length == 2);

        /// <summary>
        /// Digit two overlaps with digit one at exactly one position - c.
        /// </summary>
        public (int indexOfTwo, int indexOfC) Find2AndC(char[] one)
        {
            return (1, 1);
        }

        public int Find3()
        {
            return 0;
        }

        public int FindDigitFour() => TenSignalPatterns.IndexOf(e => e.Length == 4);

        public int Find5()
        {
            return 0;
        }

        public virtual int Find6()
        {
            return 0;
        }

        // 7 compared to 1 has 1 extra segment.
        // **a**, c, f - known.
        // 1, 2, 4, 5, 7, 8 - known.
        public int FindDigitSeven() => TenSignalPatterns.IndexOf(e => e.Length == 3);

        public int FindDigitEight() => TenSignalPatterns.IndexOf(e => e.Length == 7);

        public int Find9()
        {
            return 0;
        }

        public static DisplayExperimentV2 Parse(string experimentText)
        {
            var (tenSignalPatterns, fourDigitsOutput) = ParseParts(experimentText);
            return new DisplayExperimentV2(tenSignalPatterns, fourDigitsOutput);
        }
    }

    public class DisplayExperimentV1 : DisplayExperiment
    {
        private DisplayExperimentV1(string[] tenSignalPatterns, string[] fourDigitsOutput) : base(tenSignalPatterns, fourDigitsOutput)
        {
        }

        public int FindDigitOne() => FourDigitsOutput.IndexOf(e => e.Length == 2);
        public int FindDigitFour() => FourDigitsOutput.IndexOf(e => e.Length == 4);
        public int FindDigitSeven() => FourDigitsOutput.IndexOf(e => e.Length == 3);
        public int FindDigitEight() => FourDigitsOutput.IndexOf(e => e.Length == 7);

        public static DisplayExperimentV1 Parse(string experimentText)
        {
            var (tenSignalPatterns, fourDigitsOutput) = ParseParts(experimentText);
            return new DisplayExperimentV1(tenSignalPatterns, fourDigitsOutput);
        }
    }

    public abstract class DisplayExperiment
    {
        protected char[][] TenSignalPatterns { get; }
        protected char[][] FourDigitsOutput { get; }

        protected DisplayExperiment(string[] tenSignalPatterns, string[] fourDigitsOutput)
        {
            TenSignalPatterns = tenSignalPatterns
                .Select(pattern => pattern.Trim().ToCharArray())
                .ToArray();

            FourDigitsOutput = fourDigitsOutput
                .Select(pattern => pattern.Trim().ToCharArray())
                .ToArray(); ;
        }

        public char[] GetSignalPattern(int signalPatternIndex)
        {
            if (signalPatternIndex >= TenSignalPatterns.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(signalPatternIndex));
            }

            return TenSignalPatterns[signalPatternIndex];
        }

        public char[] GetDigitOutput(int digitOutputIndex)
        {
            if (digitOutputIndex >= FourDigitsOutput.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(digitOutputIndex));
            }

            return FourDigitsOutput[digitOutputIndex];
        }

        protected static (string[], string[]) ParseParts(string experimentText)
        {
            var parts = experimentText.Split('|');
            var tenSignalPatterns = parts[0]
                .Trim()
                .Split(' ');

            var fourDigitsOutput = parts[1]
                .Trim()
                .Split(' ');

            return (tenSignalPatterns, fourDigitsOutput);
        }
    }
}
