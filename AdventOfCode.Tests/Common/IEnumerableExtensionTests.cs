using AdventOfCode.Common;

namespace AdventOfCode.Tests.Common
{
    public class IEnumerableExtensionTests
    {
        [Theory]
        [InlineData(new[] { 3, 7, 5 }, 5)]
        [InlineData(new[] { 3 }, 3)]
        [InlineData(new[] { 3, 2, 1, 4 }, 2.5)]
        public void FindMedian_ReturnsSumOf2MiddleElementsOrMiddle(int[] numbers, double expectedMedian)
        {
            var median = numbers.Median();

            median.Should().Be(expectedMedian);
        }

        [Fact]
        public void FindMedian_WhenNoNumbers_ThrowsInvalidOperationException()
        {
            var emptyNumbers = Array.Empty<int>();

            Action medianOfEmptyNumbers = () => emptyNumbers.Median();

            medianOfEmptyNumbers.Should().Throw<InvalidOperationException>();
        }
    }
}
