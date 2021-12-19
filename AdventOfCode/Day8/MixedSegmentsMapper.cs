namespace AdventOfCode.Day8;

public static class MixedSegmentsDecoder
{
    /// <summary>
    /// Maps tangled digits to their equivalents.
    /// </summary>
    /// <returns>Dictionary of key (digit) and translated value (segments) pairs.</returns>
    public static Dictionary<int, char[]> Decode(DisplayExperimentV2 experiment)
    {
        var knownDigits = new Dictionary<int, char[]>();
        var knownSegments = new Dictionary<char, char>();

        knownDigits[1] = experiment.FindDigitOne();
        knownDigits[4] = experiment.FindDigitFour();
        knownDigits[7] = experiment.FindDigitSeven();
        knownDigits[8] = experiment.FindDigitEight();

        var (digitTwo, segmentC) = experiment.FindDigitTwoAndSegmentC(knownDigits[1], knownDigits[4]);
        knownDigits[2] = digitTwo;
        knownSegments['c'] = segmentC;

        var (digitFive, segmentF) = experiment.FindDigitFiveAndSegmentF(knownDigits[1], knownDigits[4]);
        knownDigits[5] = digitFive;
        knownSegments['f'] = segmentF;

        var segmentA = experiment.FindSegmentA(knownDigits[7], knownDigits[1]);
        knownSegments['a'] = segmentA;

        var (digitThree, segmentD, segmentB) = experiment.FindDigitThreeAndSegmentDAndSegmentB(knownDigits[1], knownDigits[4]);
        knownDigits[3] = digitThree;
        knownSegments['d'] = segmentD;
        knownSegments['b'] = segmentB;

        var (digitSix, segmentE) = experiment.FindDigitSixAndSegmentE(knownDigits[5], knownSegments['c']);
        knownDigits[6] = digitSix;
        knownSegments['e'] = segmentE;

        var segmentG = experiment.FindSegmentG(knownSegments.Values.ToArray());
        knownSegments['g'] = segmentG;

        var digitZero = experiment.FindDigit(0, knownSegments);
        knownDigits[0] = digitZero;

        var digitNine = experiment.FindDigit(9, knownSegments);
        knownDigits[9] = digitNine;

        return knownDigits;
    }
}