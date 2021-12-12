using AdventOfCode.Day7;

namespace AdventOfCode.Tests.Day7;

public class CrabSubmarines
{
    public class V1Tests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 2)]
        [InlineData(new[] { 1 }, 1)]
        [InlineData(new[] { 1, 3, 1 }, 1)]
        [InlineData(new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 }, 2)]
        public void GetOptimalAlignment(int[] crabSubmarineAlignments, int expectedOptimal)
        {
            var submarines = new CrabSubmarinesV1(crabSubmarineAlignments);

            var optimalAlignment = submarines.GetOptimalAlginment();

            optimalAlignment.Should().Be(expectedOptimal);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 2, 2)]
        [InlineData(new[] { 1 }, 1, 0)]
        [InlineData(new[] { 2 }, 1, 1)]
        [InlineData(new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 }, 2, 37)]
        public void GetFuelCostToMoveTo_SumsDistancesOfEachSubmarineToTheDesitination(int[] crabSubmarineAlignments, int horizontalToMoveTo, int expectedCost)
        {
            var submarines = new CrabSubmarinesV1(crabSubmarineAlignments);

            var optimalAlignment = submarines.CalculateFuelCostTo(horizontalToMoveTo);

            optimalAlignment.Should().Be(expectedCost);
        }
    }

    public class V2Tests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 2)]
        [InlineData(new[] { 1 }, 1)]
        [InlineData(new[] { 1, 3, 1 }, 2)]
        [InlineData(new[] { 0, 0, 0, 0, 5 }, 1)]
        [InlineData(new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 }, 5)]
        public void GetOptimalAlignment(int[] crabSubmarineAlignments, int expectedOptimal)
        {
            var submarines = new CrabSubmarinesV2(crabSubmarineAlignments);

            var optimalAlignment = submarines.GetOptimalAlginment();

            optimalAlignment.Should().Be(expectedOptimal);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 2, 2)]
        [InlineData(new[] { 1 }, 3, 3)]
        [InlineData(new[] { 0, 0, 0, 0, 5 }, 0, 15)]
        [InlineData(new[] { 0, 0, 0, 0, 5 }, 1, 14)]
        [InlineData(new[] { 1 }, 4, 6)]
        [InlineData(new[] { 2 }, 1, 1)]
        [InlineData(new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 }, 5, 168)]
        public void GetFuelCostToMoveTo_SumsDistancesOfEachSubmarineToTheDesitination(int[] crabSubmarineAlignments, int horizontalToMoveTo, int expectedCost)
        {
            var submarines = new CrabSubmarinesV2(crabSubmarineAlignments);

            var optimalAlignment = submarines.CalculateFuelCostTo(horizontalToMoveTo);

            optimalAlignment.Should().Be(expectedCost);
        }
    }
}