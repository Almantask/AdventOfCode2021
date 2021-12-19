using AdventOfCode.Day8;

namespace AdventOfCode.Tests.Day8
{
    public class MixedSegmentsMapperTests
    {
        [Fact]
        public void Decode_ReturnsDigitsMap()
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

            var untangled = MixedSegmentsDecoder.Decode(experiment);

            untangled.Should().BeEquivalentTo(expectedUntangled);
        }
    }
}
