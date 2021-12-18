namespace AdventOfCode.Day8
{

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
