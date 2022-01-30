using AdventOfCode.Day8;

namespace AdventOfCode.Tests.Day8
{
    public class MixedSegmentsMapperTests
    {
        [Theory]
        [MemberData(nameof(DecodeExpectations))]
        public void Decode_ReturnsDigitsMap(DisplayExperimentV2 experiment, Dictionary<int, char[]> expectedDecoded)
        {
            var untangled = MixedSegmentsDecoder.Decode(experiment);

            untangled.Should().BeEquivalentTo(expectedDecoded);
        }

        public static IEnumerable<object[]> DecodeExpectations
        {
            get
            {
                const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | acedgfb fcadb cdfeb cdbaf";
                var experiment1 = DisplayExperimentV2.Parse(standardExperiment);
                var expectedUntangled1 = new Dictionary<int, char[]>
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
                yield return new object[] { experiment1, expectedUntangled1 };

                const string standardExperiment2 = "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe";
                var experiment2 = DisplayExperimentV2.Parse(standardExperiment2);
                var expectedUntangled2 = new Dictionary<int, char[]>
                {
                    {0, new [] { 'a', 'b', 'd', 'e', 'f', 'g' } },
                    {1, new [] { 'b', 'e' } },
                    {2, new [] { 'a', 'b', 'c', 'd', 'f' } },
                    {3, new [] { 'b', 'c', 'd', 'e', 'f' } },
                    {4, new [] { 'b', 'c', 'e', 'g' } },
                    {5, new [] { 'c', 'd', 'e', 'f', 'g' } },
                    {6, new [] { 'a', 'c', 'd', 'e', 'f', 'g' } },
                    {7, new [] { 'e', 'b', 'd' } },
                    {8, new [] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } },
                    {9, new [] { 'b', 'c', 'd', 'e', 'f', 'g' } }
                };
                yield return new object[] { experiment2, expectedUntangled2 };
            }
        }
    }
}
