using AdventOfCode.Day8;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day8;

public abstract class DisplayExperimentTests
{
    [Fact]
    public void GetSignalPattern_WhenMoreThan10_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const int moreThan10 = 11;
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";
        DisplayExperiment experiment = InitializeExperiment(standardExperiment);

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
        var experiment = InitializeExperiment(standardExperiment);

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
        var experiment = InitializeExperiment(experimentText);

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

    protected abstract DisplayExperiment InitializeExperiment(string experiment);
}