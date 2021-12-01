using AdventOfCode.Day1;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Day1
{
    public class DepthAnalyzerTests
    {
        [Theory]
        [MemberData(nameof(ExpectedMeasureIncreases))]
        public void CountIncreases_ReturnsCountOfIncreases(long[] depthMeasurements, long expectedIncreases)
        {
            var increases = DepthAnalyzer.CountIncreases(depthMeasurements);

            increases.Should().Be(expectedIncreases);
        }

        public static IEnumerable<object[]> ExpectedMeasureIncreases
        {
            get
            {
                yield return new object[] { new long[] { 1, 1 }, 0 };
                yield return new object[] { new long[] { 1, 2 }, 1 };
                yield return new object[] { new long[] { 1, 3, 4 }, 2 };
                yield return new object[] { new long[] { 1, 2, 1 }, 1 };
                yield return new object[] { new long[] { 1, 2, 2 }, 1 };
                yield return new object[] { new long[] { 1, 2, 1, 2 }, 2 };
            }

        }
    }
}
