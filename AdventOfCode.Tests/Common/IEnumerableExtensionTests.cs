using AdventOfCode.Common;

namespace AdventOfCode.Tests.Common
{
    public class IEnumerableExtensionTests
    {
        [Theory]
        [InlineData(new[] { 3, 7, 5 }, 5)]
        [InlineData(new[] { 3 }, 3)]
        [InlineData(new[] { 3, 2, 1, 4 }, 2.5)]
        public void FindMedian_(int[] numbers, double expectedMedian)
        {
            var median = numbers.FindMedian();

            median.Should().Be(expectedMedian);
        }
    }
}
