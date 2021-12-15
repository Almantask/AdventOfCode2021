namespace AdventOfCode.Day8
{
    public class DisplayExperiment
    {
        private readonly char[][] _tenSignalPatterns;
        private readonly char[][] _fourDigitsOutput;

        private DisplayExperiment(string[] tenSignalPatterns, string[] fourDigitsOutput)
        {
            _tenSignalPatterns = tenSignalPatterns
                .Select(pattern => pattern.Trim().ToCharArray())
                .ToArray();

            _fourDigitsOutput = fourDigitsOutput
                .Select(pattern => pattern.Trim().ToCharArray())
                .ToArray(); ;
        }

        public char[] GetSignalPattern(int signalPatternIndex)
        {
            if (signalPatternIndex >= _tenSignalPatterns.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(signalPatternIndex));
            }

            return _tenSignalPatterns[signalPatternIndex];
        }

        public char[] GetDigitOutput(int digitOutputIndex)
        {
            if (digitOutputIndex >= _fourDigitsOutput.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(digitOutputIndex));
            }

            return _fourDigitsOutput[digitOutputIndex];
        }

        public static DisplayExperiment Parse(string experimentText)
        {
            var parts = experimentText.Split('|');
            var tenSignalPatterns = parts[0]
                .Trim()
                .Split(' ');

            var fourDigitsOutput = parts[1]
                .Trim()
                .Split(' ');

            return new DisplayExperiment(tenSignalPatterns, fourDigitsOutput);
        }
    }
}
