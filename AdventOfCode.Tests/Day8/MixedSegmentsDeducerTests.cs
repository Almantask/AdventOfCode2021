using AdventOfCode.Day8;

namespace AdventOfCode.Tests.Day8
{
    public class MixedSegmentsMapper
    {
        /// <summary>
        /// Maps tangled digits to their equivalents.
        /// </summary>
        /// <returns>Dictionary of key (digit) and translated value (segments) pairs.</returns>
        public Dictionary<int, char[]> UntangleDigits(DisplayExperimentV2 experiment)
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

            var digitZero = experiment.FindDigitZero(knownSegments);
            knownDigits[0] = digitZero;

            var digitNine = experiment.FindDigitNine(knownSegments);
            knownDigits[9] = digitNine;

            return knownDigits;
        }
    }

    public class MixedSegmentsMapperTests
    {
        private readonly MixedSegmentsMapper _mixedSegmentsMapper;

        public MixedSegmentsMapperTests()
        {
            _mixedSegmentsMapper = new MixedSegmentsMapper();
        }

        [Fact]
        public void UntangleDigits_ReturnsDigitsMap()
        {
            const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | acedgfb fcadb cdfeb cdbaf";
            var experiment = DisplayExperimentV2.Parse(standardExperiment);
            var expectedUntangled = new Dictionary<int, char[]>()
            {
                {0, new [] { 'c','a','g','e','d','b' } },
                {1, new [] { 'a','b' } },
                {2, new [] { 'g','c','d','f','a' } },
                {3, new [] { 'f','b','c','a','d' } },
                {4, new [] { 'e','a','f','b' } },
                {5, new [] { 'c','d','f','b','e' } },
                {6, new [] { 'c','d','f','g','e','b' } },
                {7, new [] { 'd','a','b' } },
                {8, new [] { 'a','c','e','d','g','f','b' } },
                {9, new [] { 'c','e','f','a','b','d' } }
            };

            var untangled = _mixedSegmentsMapper.UntangleDigits(experiment);

            untangled.Should().BeEquivalentTo(expectedUntangled);
        }
    }
}
