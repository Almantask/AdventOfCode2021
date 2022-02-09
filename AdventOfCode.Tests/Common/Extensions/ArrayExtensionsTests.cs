using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Tests.Common.Extensions
{
    public class ArrayExtensionsTests
    {
        [Fact]
        public void To2D_WhenMultidimensionalArrayIsRectangular_ReturnsJaggedArray()
        {
            var rectangular2DArray = new[]
            {
                new[] { 1, 2 },
                new[] { 3, 4 },
                new[] { 5, 6 },
            };

            var twoDimensionalArray = rectangular2DArray.To2D();

            twoDimensionalArray[0, 0].Should().Be(1);
            twoDimensionalArray[0, 1].Should().Be(2);
            twoDimensionalArray[1, 0].Should().Be(3);
            twoDimensionalArray[1, 1].Should().Be(4);
            twoDimensionalArray[2, 0].Should().Be(5);
            twoDimensionalArray[2, 1].Should().Be(6);
        }

        [Fact]
        public void To2D_WhenMultidimensionalArrayIsNotRectangular_ThrowsInvalidOperationException()
        {
            var rectangular2DArray = new[]
            {
                new[] { 1, 2 },
                new[] { 1 }
            };

            Action to2DWhenNotRectangularArray = () => rectangular2DArray.To2D();

            to2DWhenNotRectangularArray.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ShiftToLeftBy1_ShiftsArrayElementsBy1ToLeft()
        {
            int[] elements = { 2, 6, 5 };
            int[] expectedElements = { 6, 5, 2 };

            elements.ShiftBy1ToLeft();

            elements.Should().BeEquivalentTo(expectedElements);
        }

        [Fact]
        public void IndexOf_GivenElementExists_ReturnsIndexOfElement()
        {
            int[] elements = { 1, 2, 3 };

            var index = elements.IndexOf(e => e == 2);

            index.Should().Be(1);
        }

        [Fact]
        public void IndexOf_GivenElementExistsMultipleTimes_ReturnsIndexOfFirstOccurence()
        {
            int[] elements = { 2, 2, 3 };

            var index = elements.IndexOf(e => e == 2);

            index.Should().Be(0);
        }

        [Fact]
        public void IndexOf_GivenElementDoesNotExist_ReturnsMinusOne()
        {
            int[] elements = { 1, 2, 3 };

            var index = elements.IndexOf(e => e == 4);

            index.Should().Be(-1);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, true)]
        [InlineData(new[] { 1, 3 }, new[] { 1, 2, 3 }, false)]
        [InlineData(new[] { 1, 4, 3 }, new[] { 1, 2, 3 }, false)]
        [InlineData(new int[0], new int[0], true)]
        [InlineData(null, new int[0], false)]
        [InlineData(new int[0], null, false)]
        [InlineData(null, null, false)]
        public void IsEquivalentTo_ReturnsTrueWhenBothArrayNotNullAndEquivalent(int[] a, int[] b, bool expectedIsEquivalent)
        {
            var isEquivalentTo = a.IsEquivalentTo(b);

            isEquivalentTo.Should().Be(expectedIsEquivalent);
        }
    }
}
