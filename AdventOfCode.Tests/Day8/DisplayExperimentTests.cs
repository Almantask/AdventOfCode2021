using AdventOfCode.Day8;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day8;

public class DisplayExperimentTests
{
    // Different digits will have overlapping lit segments.
    // This can be used to deduce which actual segments are lit.

    // 1, 4, 7 and 8 - known.

    // Consider 1 (c,f) for example
    // 2 (a,**c**,d,e,g) and 5 (a,b,d,**f**,g)
    // Knowing the overlapping segments - we can deduce whether c and f were mixed or not.

    // 1 is our start. Use 2 and 5 to deduce exact positions (because they overlap at exactly one place).
    // c, f - known.
    // 1, 2, 4, 7 - known.

    // 7 is next up and is an easy one (because there is only 1 extra segment) and it has unique segments count.
    // **a**, c, f - known.
    // 1, 2, 4, 7 - known.

    // We will analyze 4 next (last number with unique count). b and d are unknown.
    // 5 is the only number that has 2 segments off and overlaps with a 4 at a single place - b.
    // The remaining segment in 4 is d.
    // a, **b**, c, **d**, f - known.
    // 1, 2, 4, **5**, 7 - known.

    // 6 overlaps in all places but 1 with 5. The non-overlapping segment - e.
    // a, b, c, d, **e**, f - known.
    // 1, 2, 4, 5, **6**, 7 - known.

    // The last missing segment is g. With it, we can deduce the remaining numbers.
    // a, b, c, d, e, f, **g** - known.
    // **0**, 1, 2, **3**, 4, 5, 6, 7 - known.

    [Fact]
    public void GetSignalPattern_WhenMoreThan10_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const int moreThan10 = 11;
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";
        var experiment = DisplayExperiment.Parse(standardExperiment);

        // Act
        Action getDigitOutputMoreThan10 = () => experiment.GetSignalPattern(moreThan10);

        // Assert
        getDigitOutputMoreThan10.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GetDigitOutput_WhenMoreThan4_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const int moreThan4 = 5;
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";
        var experiment = DisplayExperiment.Parse(standardExperiment);

        // Act
        Action getDigitOutputMoreThan10 = () => experiment.GetDigitOutput(moreThan4);

        // Assert
        getDigitOutputMoreThan10.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Parse_ReturnsExpectedSignalsAndDigitOutput()
    {
        // Arrange
        const string experimentText = @"acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab |
            cdfeb fcadb cdfeb cdbaf";

        char[][] _tenSignalPatterns = {
            new[] { 'a', 'c', 'e', 'd', 'g', 'f', 'b' },
            new[] { 'c', 'd', 'f', 'b', 'e' },
            new[] { 'g', 'c', 'd', 'f', 'a' },
            new[] { 'f', 'b', 'c', 'a', 'd' },
            new[] { 'd', 'a', 'b' },
            new[] { 'c', 'e', 'f', 'a', 'b', 'd' },
            new[] { 'c', 'd', 'f', 'g', 'e', 'b' },
            new[] { 'e', 'a', 'f', 'b' },
            new[] { 'c', 'a', 'g', 'e', 'd', 'b' },
            new[] { 'a', 'b' }
        };
        char[][] _fourDigitsOutput =
        {
            new[] { 'c', 'd', 'f', 'e', 'b' },
            new[] { 'f', 'c', 'a', 'd', 'b' },
            new[] { 'c', 'd', 'f', 'e', 'b' },
            new[] { 'c', 'd', 'b', 'a', 'f' },
        };

        // Act
        var experiment = DisplayExperiment.Parse(experimentText);

        // Assert
        using (new AssertionScope())
        {
            for (int i = 0; i < _tenSignalPatterns.GetLength(0); i++)
            {
                var signalPattern = experiment.GetSignalPattern(i);
                signalPattern.Should().BeEquivalentTo(_tenSignalPatterns[i]);
            }

            for (int i = 0; i < _fourDigitsOutput.GetLength(0); i++)
            {
                var signalPattern = experiment.GetDigitOutput(i);
                signalPattern.Should().BeEquivalentTo(_fourDigitsOutput[i]);
            }
        }
    }
}