using AdventOfCode.Day8;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day8;

public class DisplayExperimentV2Tests : DisplayExperimentTests
{
    private const string Any = "xxxxxxxxxxxxxxx";
    private const string Zero = "cagedb";
    private const string One = "ab";
    private const string Two = "gcdfa";
    private const string Three = "fbcad";
    private const string Four = "eafb";
    private const string Five = "cdfbe";
    private const string Six = "cdfgeb";
    private const string Seven = "dab";
    private const string Eight = "acedgfb";
    private const string Nine = "cefabd";

    // Indexes of digit come from signals (not output)

    [Fact]
    public void FindDigitOne_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} {One} {Any} | {Any}";
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var indexOf1 = experiment.FindDigitOne();

        // Assert
        indexOf1.Should().Be(1);
    }

    [Fact]
    public void FindDigitFour_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} {Four} {Any} | {Any}";
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var indexOf4 = experiment.FindDigitFour();

        // Assert
        indexOf4.Should().Be(1);
    }

    [Fact]
    public void FindDigitSeven_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} {Seven} {Any} | {Any}";
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var indexOf4 = experiment.FindDigitSeven();

        // Assert
        indexOf4.Should().Be(1);
    }

    [Fact]
    public void FindDigitEight_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} {Eight} {Any} | {Any}";
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var indexOf4 = experiment.FindDigitEight();

        // Assert
        indexOf4.Should().Be(1);
    }

    [Fact]
    public void FindDigitTwoAndSegmentC_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} {Two} {One} {Four} | {Any}";
        char[] digitOne = One.ToCharArray();
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var (indexOfDigitTwo, segmentC) = experiment.FindDigitTwoAndSegmentC(digitOne, Four.ToCharArray());

        // Assert
        using (new AssertionScope())
        {
            indexOfDigitTwo.Should().Be(1, "Digit two overlaps with digit four at 2 segments.");
            segmentC.Should().Be('a', "Digit two overlaps with digit one at exactly 1 segment");
        }
    }

    [Fact]
    public void FindDigitFiveAndSegmentF_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} {Five} {One} {Four} | {Any}";
        char[] digitOne = One.ToCharArray();
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var (indexOfDigitFive, segmentC) = experiment.FindDigitFiveAndSegmentF(digitOne, Four.ToCharArray());

        // Assert
        using (new AssertionScope())
        {
            indexOfDigitFive.Should().Be(1, "Digit five overlaps with digit four at 3 segments.");
            segmentC.Should().Be('b', "Digit five overlaps with digit one at exactly 1 segment");
        }
    }

    [Fact]
    public void FindSegmentA_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Seven} {One} | {Any}";
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var segmentA = experiment.FindSegmentA(Seven.ToCharArray(), One.ToCharArray());

        // Assert
        segmentA.Should().Be('d', "Digit seven compared to digit one has 1 extra segment");
    }

    [Fact]
    public void FindDigitThreeAndSegmentDAndSegmentB_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} {One} {Four} {Three} | {Any}";
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var (indexOfDigitThree, segmentD, segmentB) = experiment.FindDigitThreeAndSegmentDAndSegmentB(One.ToCharArray(), Four.ToCharArray());

        // Assert
        using (new AssertionScope())
        {
            indexOfDigitThree.Should().Be(3, "Digit four overlaps with digit three at a 1 extra segment");
            segmentD.Should().Be('f', "Digit four overlaps with digit three at a 1 extra segment");
            segmentB.Should().Be('e', "Knowing segment d - we're left with the last segment on digit four");
        }
    }

    [Fact]
    public void FindDigitSixAndSegmentE_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} {Six} {Five} | {Any}";
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var (indexOfDigitSix, segmentE) = experiment.FindDigitSixAndSegmentE(Five.ToCharArray());

        // Assert
        using (new AssertionScope())
        {
            indexOfDigitSix.Should().Be(1, "Digit six overlaps in all segments but 1 with digit five");
            segmentE.Should().Be('g', "Digit six overlaps in all segments but 1 with digit five");
        }
    }

    [Fact]
    public void FindSegmentG_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} | {Any}";
        var experiment = DisplayExperimentV2.Parse(experimentText);
        var knownSegments = "badcge";
        var unknownSegments = "badcgef";

        // Act
        var segmentG = experiment.FindSegmentG(knownSegments.ToCharArray(), unknownSegments.ToCharArray());

        // Assert
        segmentG.Should().Be('f', "G is the last missing segment");
    }

    [Fact]
    public void FindDigitZero_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} {Zero} {Any} | {Any}";
        var segmentsMap = new Dictionary<char, char>()
        {
            {'a', 'c'},
            {'b', 'a'},
            {'c', 'g'},
            {'d', 'd'}, // ?
            {'e', 'e'},
            {'f', 'd'},
            {'g', 'b'},
        };
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var indexOfDigitZero = experiment.FindDigitZero(segmentsMap);

        // Assert
        indexOfDigitZero.Should().Be(1, $"Because digit one is made from segments: {DisplayDigit.Create(0)}");
    }

    [Fact]
    public void FindDigitNine_ReturnsExpected()
    {
        // Arrange
        const string experimentText = $"{Any} {Nine} {Any} | {Any}";
        var segmentsMap = new Dictionary<char, char>()
        {
            {'a', 'c'},
            {'b', 'e'},
            {'c', 'f'},
            {'d', 'a'},
            {'e', 'g'},
            {'f', 'd'},
            {'g', 'b'},
        };
        var experiment = DisplayExperimentV2.Parse(experimentText);

        // Act
        var indexOfDigitNine = experiment.FindDigitNine(segmentsMap);

        // Assert
        indexOfDigitNine.Should().Be(1, $"Because digit nine is made from segments: {DisplayDigit.Create(9)}");
    }

    protected override DisplayExperiment InitializeExperiment(string experiment) => DisplayExperimentV2.Parse(experiment);
}