using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Tests.Common.Extensions
{
    public class CharArrayExtensionsTests
    {
        [Theory]
        [InlineData(new[] {'0'}, 0)]
        [InlineData(new[] { '1' }, 1)]
        [InlineData(new[] { '0', '1' }, 1)]
        [InlineData(new[] {'1','0'}, 2)]
        [InlineData(new[] {'1', '1' }, 3)]
        [InlineData(new[] {'1','0','0'}, 4)]
        [InlineData(new[] {'1', '0', '0', '0'}, 8)]
        [InlineData(new[] {'1', '0', '0','1'}, 9)]
        public void ToLong_ReturnsExpectedLongAsDecimal(char[] binary, long expected)
        {
            var number = binary.ToLong();

            number.Should().Be(expected);
        }

        [Fact]
        public void ToLong_WhenIsNotMadeOf0Or1_ThrowsArgumentException()
        {
            char[] not0Or1 = new []{'0', '1', 'a'};

            var binaryToLongWhenNot0or1 = () => not0Or1.ToLong();

            binaryToLongWhenNot0or1
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("binaryNumber");
        }

        [Fact]
        public void FlipBits_WhenIsNotMadeOf0Or1_ThrowsArgumentException()
        {
            char[] not0Or1 = new[] { '0', '1', 'a' };

            var flipBitWHenNot0Or1 = () => not0Or1.FlipBits();

            flipBitWHenNot0Or1
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("binaryNumber");
        }

        [Theory]
        [InlineData(new[] {'1'}, new[] { '0' })]
        [InlineData(new[] {'0'}, new[] { '1' })]
        [InlineData(new[] {'1', '0',}, new[] { '0', '1' })]
        [InlineData(new[] {'0', '1'}, new[] { '1', '0', })]
        public void FlipBits_ReturnsNewArrayWithBitsFlipped(char[] binaryNumber, char[] expectedFlippedBits)
        {
            var flippedBits = binaryNumber.FlipBits();

            flippedBits.Should().BeEquivalentTo(expectedFlippedBits);

        }
    }
}
