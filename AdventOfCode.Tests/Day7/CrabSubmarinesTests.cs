using AdventOfCode.Day7;

namespace AdventOfCode.Tests.Day7;

public class CrabSubmarinesTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 2)]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 1, 3, 1 }, 1)]
    [InlineData(new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 }, 2)]
    public void GetOptimalAlignment(int[] crabSubmarineAlignments, int expectedOptimal)
    {
        var submarines = new CrabSubmarines(crabSubmarineAlignments);

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
        var submarines = new CrabSubmarines(crabSubmarineAlignments);

        var optimalAlignment = submarines.CalculateFuelCostTo(horizontalToMoveTo);

        optimalAlignment.Should().Be(expectedCost);
    }
}