using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day3;

public class DiagnosticReport
{
    public long PowerConsumption => GammaRate * EpsilonRate;

    public long GammaRate => MostCommonVertical.ToLong();

    public long EpsilonRate => MostCommonVertical.FlipBits().ToLong();

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
            char mostCommonBitOfHorizontal = FindBitOfHorizontalPositionByRarity(binaries, horizontal, BitRarity.MostCommon);
            mostCommonBitsAtVertical[horizontal] = mostCommonBitOfHorizontal;
        }

        return mostCommonBitsAtVertical;
    }

    protected enum BitRarity
    {
        LeastCommon,
        MostCommon
    }

    protected static char FindBitOfHorizontalPositionByRarity(char[,] binaries, int horizontal, BitRarity bitRarity)
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

        char mostCommonBitOfHorizontal;
        if (bitRarity == BitRarity.MostCommon)
        {
            // When searching for the most common bit, priority is given for 1s.
            // When same amount of 1s and 0s - 1 will be returned.
            mostCommonBitOfHorizontal = zeros > ones ? '0' : '1';
        }
        else
        {
            // When searching for least common bit, priority is given for 0s.
            // When same amount of 1s and 0s - 0 will be returned.
            mostCommonBitOfHorizontal = zeros <= ones ? '0' : '1';
        }

        return mostCommonBitOfHorizontal;
    }
}