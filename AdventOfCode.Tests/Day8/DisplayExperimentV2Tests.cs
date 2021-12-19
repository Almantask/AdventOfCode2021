using AdventOfCode.Day8;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day8;

public abstract class DisplayExperimentV2Tests : DisplayExperimentTests
{
    protected abstract string Zero { get; }
    protected abstract string One { get; }
    protected abstract string Two { get; }
    protected abstract string Three { get; }
    protected abstract string Four { get; }
    protected abstract string Five { get; }
    protected abstract string Six { get; }
    protected abstract string Seven { get; }
    protected abstract string Eight { get; }
    protected abstract string Nine { get; }

    private readonly DisplayExperimentV2 _experiment;

    protected DisplayExperimentV2Tests()
    {
        var experimentString = BuildExperimentString();
        _experiment = DisplayExperimentV2.Parse(experimentString);
    }

    [Fact]
    public void FindDigitOne_ReturnsExpected()
    {
        var digitOneSegments = _experiment.FindDigitOne();

        digitOneSegments.Should().BeEquivalentTo(One.ToCharArray());
    }

    [Fact]
    public void FindDigitFour_ReturnsExpected()
    {
        var digitFourSegments = _experiment.FindDigitFour();

        digitFourSegments.Should().BeEquivalentTo(Four.ToCharArray());
    }

    [Fact]
    public void FindDigitSeven_ReturnsExpected()
    {
        var digitSevenSegments = _experiment.FindDigitSeven();

        digitSevenSegments.Should().BeEquivalentTo(Seven.ToCharArray());
    }

    [Fact]
    public void FindDigitEight_ReturnsExpected()
    {
        var digitEightSegments = _experiment.FindDigitEight();

        digitEightSegments.Should().BeEquivalentTo(Eight.ToCharArray());
    }

    [Fact]
    public void FindDigitTwoAndSegmentC_ReturnsExpected()
    {
        var (digitTwoSegments, segmentC) = _experiment.FindDigitTwoAndSegmentC(One.ToCharArray(), Four.ToCharArray());

        using (new AssertionScope())
        {
            digitTwoSegments.Should().BeEquivalentTo(Two.ToCharArray(), "Digit two overlaps with digit four at 2 segments.");
            segmentC.Should().Be('a', "Digit two overlaps with digit one at exactly 1 segment");
        }
    }

    [Fact]
    public void FindDigitFiveAndSegmentF_ReturnsExpected()
    {
        var (digitFiveSegments, segmentC) = _experiment.FindDigitFiveAndSegmentF(One.ToCharArray(), Four.ToCharArray());

        using (new AssertionScope())
        {
            digitFiveSegments.Should().BeEquivalentTo(Five.ToCharArray(), "Digit five overlaps with digit four at 3 segments.");
            segmentC.Should().Be('b', "Digit five overlaps with digit one at exactly 1 segment");
        }
    }

    [Fact]
    public void FindSegmentA_ReturnsExpected()
    {
        var segmentA = _experiment.FindSegmentA(Seven.ToCharArray(), One.ToCharArray());

        segmentA.Should().Be('d', "Digit seven compared to digit one has 1 extra segment");
    }

    [Fact]
    public void FindDigitThreeAndSegmentDAndSegmentB_ReturnsExpected()
    {
        var (digitThreeSegments, segmentD, segmentB) = _experiment.FindDigitThreeAndSegmentDAndSegmentB(One.ToCharArray(), Four.ToCharArray());

        using (new AssertionScope())
        {
            digitThreeSegments.Should().BeEquivalentTo(Three.ToCharArray(), "Digit four overlaps with digit three at a 1 extra segment");
            segmentD.Should().Be('f', "Digit four overlaps with digit three at a 1 extra segment");
            segmentB.Should().Be('e', "Knowing segment d - we're left with the last segment on digit four");
        }
    }

    [Fact]
    public void FindDigitSixAndSegmentE_ReturnsExpected()
    {
        var (digitSixSegments, segmentE) = _experiment.FindDigitSixAndSegmentE(Five.ToCharArray(), 'a');

        using (new AssertionScope())
        {
            digitSixSegments.Should().BeEquivalentTo(Six.ToCharArray(), "Digit six overlaps in all segments but 1 with digit five");
            segmentE.Should().Be('g', "Digit six overlaps in all segments but 1 with digit five");
        }
    }

    [Fact]
    public void FindSegmentG_ReturnsExpected()
    {
        var knownSegments = "badcge".ToCharArray();

        var segmentG = _experiment.FindSegmentG(knownSegments);

        segmentG.Should().Be('f', "G is the last missing segment");
    }

    // Not very clean, because the values are hardcoded.
    // However, they cannot be constants because digits come as properties and not constants.
    // Too much of a hassle to refactor.
    [Theory]
    [InlineData(0, "cagedb")]
    [InlineData(1, "ab")]
    [InlineData(2, "gcdfa")]
    [InlineData(3, "fbcad")]
    [InlineData(4, "eafb")]
    [InlineData(5, "cdfbe")]
    [InlineData(6, "cdfgeb")]
    [InlineData(7, "dab")]
    [InlineData(8, "acedgfb")]
    [InlineData(9, "cefabd")]
    public void FindDigit_ReturnsExpected(int digit, string expectedSegmentsText)
    {
        var segmentsMap = new Dictionary<char, char>()
        {
            {'a', 'd'},
            {'b', 'e'},
            {'c', 'a'},
            {'d', 'f'},
            {'e', 'g'},
            {'f', 'b'},
            {'g', 'c'},
        };

        var digitZeroSegments = _experiment.FindDigit(digit, segmentsMap);

        digitZeroSegments.Should().BeEquivalentTo(expectedSegmentsText.ToCharArray());
    }

    protected abstract string BuildExperimentString();
    protected override DisplayExperiment InitializeExperiment(string experiment) => DisplayExperimentV2.Parse(experiment);

}


public class DisplayExperimentV2Tests1 : DisplayExperimentV2Tests
{
    protected override string Zero => "cagedb";
    protected override string One => "ab";
    protected override string Two => "gcdfa";
    protected override string Three => "fbcad";
    protected override string Four => "eafb";
    protected override string Five => "cdfbe";
    protected override string Six => "cdfgeb";
    protected override string Seven => "dab";
    protected override string Eight => "acedgfb";
    protected override string Nine => "cefabd";

    protected override string BuildExperimentString() => $"{Two} {Three} {Four} {One} {Zero} {Six} {Seven} {Eight} {Five} {Nine}| {Zero} {One} {One} {Five}";
}