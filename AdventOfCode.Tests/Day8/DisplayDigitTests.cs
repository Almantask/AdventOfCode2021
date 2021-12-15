using AdventOfCode.Day8;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day8
{
    public class DisplayDigitTests
    {
        [Theory]
        [InlineData(0, new[] { 'a', 'b', 'c', 'e', 'f', 'g' }, false)]
        [InlineData(0, new[] { 'a', 'b', 'c', 'e', 'f' }, false)]
        [InlineData(1, new[] { 'x', 'y' }, true)]
        [InlineData(1, new[] { 'c', 'f' }, true)]
        [InlineData(1, new[] { 'c', 'f', 'z' }, false)]
        [InlineData(2, new[] { 'a', 'c', 'd', 'e', 'g' }, false)]
        [InlineData(3, new[] { 'a', 'c', 'd', 'f', 'g' }, false)]
        [InlineData(4, new[] { 'b', 'c', 'd', 'f' }, true)]
        [InlineData(5, new[] { 'a', 'b', 'd', 'f', 'g' }, false)]
        [InlineData(6, new[] { 'a', 'b', 'd', 'e', 'f', 'g' }, false)]
        [InlineData(7, new[] { 'x', 'y', 'z' }, true)]
        [InlineData(7, new[] { 'x', 'y' }, false)]
        [InlineData(8, new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'l' }, true)]
        [InlineData(9, new[] { 'a', 'b', 'c', 'd', 'f', 'g' }, false)]
        public void IsGuaranteedToBeMadeFromRandomSegments_ReturnsTrueWhenUniqueCountMatchesThePassedSegmentsCount(int digit, char[] segments, bool expectedCanSegmentsCreateDigit)
        {
            var displayDigit = DisplayDigit.Create(digit);

            var canBeMadeFromRandomSegments = displayDigit.IsGuaranteedToBeMadeFromRandomSegments(segments);

            canBeMadeFromRandomSegments.Should().Be(expectedCanSegmentsCreateDigit);
        }

        [Theory]
        [InlineData(0, new[] { 'a', 'b', 'c', 'e', 'f', 'g' })]
        [InlineData(1, new[] { 'c', 'f' })]
        [InlineData(2, new[] { 'a', 'c', 'd', 'e', 'g' })]
        [InlineData(3, new[] { 'a', 'c', 'd', 'f', 'g' })]
        [InlineData(4, new[] { 'b', 'c', 'd', 'f' })]
        [InlineData(5, new[] { 'a', 'b', 'd', 'f', 'g' })]
        [InlineData(6, new[] { 'a', 'b', 'd', 'e', 'f', 'g' })]
        [InlineData(7, new[] { 'a', 'c', 'f' })]
        [InlineData(8, new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' })]
        [InlineData(9, new[] { 'a', 'b', 'c', 'd', 'f', 'g' })]
        public void Create_WhenDigitLessThan9AndMoreThanOrEqualTo0_ReturnsDigitOutOfExpectedSegments(int digit, char[] expectedSegments)
        {
            var displayDigit = DisplayDigit.Create(digit);

            using (new AssertionScope())
            {
                displayDigit.Digit.Should().Be(digit);
                displayDigit.Segments.Should().BeEquivalentTo(expectedSegments);
            }
        }

        [Fact]
        public void Create_WhenDigitMoreThan9_ThrowsArgumentOutOfRangeException()
        {
            const int digitOutOfRange = 10;
            Action createDisplayDigitOutOfRange = () => DisplayDigit.Create(digitOutOfRange);

            createDisplayDigitOutOfRange.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
