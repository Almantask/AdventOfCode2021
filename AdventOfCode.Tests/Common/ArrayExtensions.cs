using AdventOfCode.Common;

namespace AdventOfCode.Tests.Common
{
    public class ArrayExtensions
    {
        [Fact]
        public void ToJaggedArray_WhenMultidimensionalArrayIsRectangular_ReturnsJaggedArray()
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
        public void ToJaggedArray_WhenMultidimensionalArrayIsNotRectangular_ThrowsInvalidOperationException()
        {
            var rectangular2DArray = new[]
            {
                new[] { 1, 2 },
                new[] { 1 }
            };

            Action toJaggedArrayWhenNotRectangular = () => rectangular2DArray.To2D();
        }

        [Fact]
        public void ShiftToLeftBy1_ShiftsArrayElementsBy1ToLeft()
        {
            int[] elements = { 2, 6, 5 };
            int[] expectedElements = { 6, 5, 2 };

            elements.ShiftBy1ToLeft();

            elements.Should().BeEquivalentTo(expectedElements);
        }
    }
}
