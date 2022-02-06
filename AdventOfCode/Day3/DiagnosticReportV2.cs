using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day3;

public class DiagnosticReportV2 : DiagnosticReport
{
    public long LifeSupportRating => OxygenGeneratorRating * Co2ScrubberRating;
    public long OxygenGeneratorRating { get; }
    public long Co2ScrubberRating { get; }

    public DiagnosticReportV2(char[,] binaryNumbers) : base(binaryNumbers)
    {
        OxygenGeneratorRating = FindOxygenGeneratorRating(binaryNumbers);
        Co2ScrubberRating = FindCo2ScrubberRating(binaryNumbers);
    }

    private static long FindOxygenGeneratorRating(char[,] binaryNumbers)
    {
        var binary = FindBinaryByBitRarity(binaryNumbers, 0, BitRarity.MostCommon);
        return binary.ToLong();
    }

    private static long FindCo2ScrubberRating(char[,] binaryNumbers)
    {
        var binary = FindBinaryByBitRarity(binaryNumbers, 0, BitRarity.LeastCommon);
        return binary.ToLong();
    }

    private static char[] FindBinaryByBitRarity(char[,] binaryNumbers, int horizontalPosition, BitRarity bitRarity)
    {
        var neededBitAtHorizontalPosition = FindBitOfHorizontalPositionByRarity(binaryNumbers, horizontalPosition, bitRarity);
        var filteredOut = new List<char[]>();
        for (var vertical = 0; vertical < binaryNumbers.GetLength(0); vertical++)
        {
            var binaryAtHorizontalPosition = binaryNumbers[vertical, horizontalPosition];
            var bitCriteriaApplies = binaryAtHorizontalPosition == neededBitAtHorizontalPosition;
            if (!bitCriteriaApplies) continue;

            var binaryNumber = GetBinaryNumberAtVertical(binaryNumbers, vertical);
            filteredOut.Add(binaryNumber);
        }

        if (filteredOut.Count == 1) return filteredOut.First();

        var filteredOut2d = filteredOut.ToArray().To2D();
        return FindBinaryByBitRarity(filteredOut2d, ++horizontalPosition, bitRarity);
    }

    private static char[] GetBinaryNumberAtVertical(char[,] binaryNumbers, int vertical)
    {
        var binaryNumber = new char[binaryNumbers.GetLength(1)];
        for (var horizontal = 0; horizontal < binaryNumbers.GetLength(1); horizontal++)
        {
            var binaryDigit = binaryNumbers[vertical, horizontal];
            binaryNumber[horizontal] = binaryDigit;
        }

        return binaryNumber;
    }
}