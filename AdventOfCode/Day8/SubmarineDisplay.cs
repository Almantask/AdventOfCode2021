using AdventOfCode.Common;

namespace AdventOfCode.Day8
{
    public class SubmarineDisplay
    {
        public int Output { get; }

        public SubmarineDisplay(DisplayExperimentV2 experiment)
        {
            var decodedDigitSignals = MixedSegmentsDecoder.Decode(experiment);
            var outputDigits = new[]
            {
                DecodeOutputDigit(0),
                DecodeOutputDigit(1),
                DecodeOutputDigit(2),
                DecodeOutputDigit(3),
            };
            var outputDigitsAsText = string.Join(separator: "", outputDigits);
            Output = int.Parse(outputDigitsAsText);

            int DecodeOutputDigit(int outputDigitIndex)
            {
                return FindOutputDigit(experiment.GetDigitOutput(outputDigitIndex));
            }

            int FindOutputDigit(char[] mixedDigitSignal)
            {
                foreach (var decodedDigitSignal in decodedDigitSignals)
                {
                    if (decodedDigitSignal.Value.IsEquivalentTo(mixedDigitSignal))
                    {
                        return decodedDigitSignal.Key;
                    }
                }

                throw new InvalidOperationException("Invalid decoding. Output digit was expected in decoded map, but was not found.");
            }
        }


    }
}
