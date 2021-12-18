namespace AdventOfCode.Day8
{

    public abstract class DisplayExperiment
    {
        public int SignalsCount => SignalPatterns.Length;

        protected char[][] SignalPatterns { get; }
        protected char[][] DigitsOutput { get; }

        protected DisplayExperiment(string[] tenSignalPatterns, string[] fourDigitsOutput)
        {
            SignalPatterns = tenSignalPatterns
                .Select(pattern => pattern.Trim().ToCharArray())
                .ToArray();

            DigitsOutput = fourDigitsOutput
                .Select(pattern => pattern.Trim().ToCharArray())
                .ToArray(); ;
        }

        public char[] GetSignalPattern(int signalPatternIndex)
        {
            if (signalPatternIndex >= SignalPatterns.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(signalPatternIndex));
            }

            return SignalPatterns[signalPatternIndex];
        }

        public char[] GetDigitOutput(int digitOutputIndex)
        {
            if (digitOutputIndex >= DigitsOutput.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(digitOutputIndex));
            }

            return DigitsOutput[digitOutputIndex];
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
