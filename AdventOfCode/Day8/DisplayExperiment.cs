using AdventOfCode.Common;

namespace AdventOfCode.Day8
{
    public class DisplayExperimentV2 : DisplayExperiment
    {
        protected DisplayExperimentV2(string[] tenSignalPatterns, string[] fourDigitsOutput) : base(tenSignalPatterns, fourDigitsOutput)
        {
        }

        public int Find0()
        {
            return 0;
        }

        public int Find1() => TenSignalPatterns.IndexOf(e => e.Length == 2);

        public int Find2() => 0;

        public int Find3()
        {
            return 0;
        }

        public int Find4() => TenSignalPatterns.IndexOf(e => e.Length == 4);

        public int Find5()
        {
            return 0;
        }

        public virtual int Find6()
        {
            return 0;
        }

        public int Find7() => TenSignalPatterns.IndexOf(e => e.Length == 3);

        public int Find8() => TenSignalPatterns.IndexOf(e => e.Length == 7);

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
        public DisplayExperimentV1(string[] tenSignalPatterns, string[] fourDigitsOutput) : base(tenSignalPatterns, fourDigitsOutput)
        {
        }

        public int Find1() => FourDigitsOutput.IndexOf(e => e.Length == 2);
        public int Find4() => FourDigitsOutput.IndexOf(e => e.Length == 4);
        public int Find7() => FourDigitsOutput.IndexOf(e => e.Length == 3);
        public int Find8() => FourDigitsOutput.IndexOf(e => e.Length == 7);

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
