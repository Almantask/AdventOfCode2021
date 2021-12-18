using AdventOfCode.Day8;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day8
{
    public class DisplayDigitTests
    {
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
