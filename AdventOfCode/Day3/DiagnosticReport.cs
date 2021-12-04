using AdventOfCode.Common;

namespace AdventOfCode.Day3;

public class DiagnosticReport
{
    public long PowerConsumption => GammaRate * EpsilonRate;

    public long GammaRate => MostCommonVertical.BinaryToLong();

    public long EpsilonRate => MostCommonVertical.FlipBits().BinaryToLong();

    public char[] MostCommonVertical { get; }

    public DiagnosticReport(char[,] binaryNumbers)
    {
        MostCommonVertical = FindMostCommonBits(binaryNumbers);
    }

    private static char[] FindMostCommonBits(char[,] binaries)
    {
        var mostCommonBitsAtVertical = new char[binaries.GetLength(1)];
        for (var horizontal = 0; horizontal < binaries.GetLength(1); horizontal++)
        {
            var zeros = 0;
            var ones = 0;

            for (var vertical = 0; vertical < binaries.GetLength(0); vertical++)
            {
                var bit = binaries[vertical, horizontal];
                switch (bit)
                {
                    case '0':
                        zeros++;
                        break;
                    case '1':
                        ones++;
                        break;
                    default:
                        throw new ArgumentException("Not a bit", nameof(bit));
                }
            }
            mostCommonBitsAtVertical[horizontal] = zeros > ones ? '0' : '1';
        }

        return mostCommonBitsAtVertical;
    }
}