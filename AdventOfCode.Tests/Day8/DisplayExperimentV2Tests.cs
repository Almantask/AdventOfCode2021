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

    private readonly DisplayExperimentV2 _experiment;
    public DisplayExperimentV2Tests()
    {
        const string standardExperiment = $"{Two} {Three} {Four} {One} {Zero} {Six} {Seven} {Eight} {Five} {Nine}| {Any}";
        _experiment = DisplayExperimentV2.Parse(standardExperiment);
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

    [Fact]
    public void FindDigitZero_ReturnsExpected()
    {
        var segmentsMap = new Dictionary<char, char>()
        {
            {'a', 'c'},
            {'b', 'a'},
            {'c', 'g'},
            {'d', 'd'},
            {'e', 'e'},
            {'f', 'd'},
            {'g', 'b'},
        };

        var digitZeroSegments = _experiment.FindDigitZero(segmentsMap);

        digitZeroSegments.Should().BeEquivalentTo(Zero.ToCharArray(), $"Because digit one is made from segments: {DisplayDigit.Create(0)}");
    }

    [Fact]
    public void FindDigitNine_ReturnsExpected()
    {
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

        var digitNineSegments = _experiment.FindDigitNine(segmentsMap);

        digitNineSegments.Should().BeEquivalentTo(Nine.ToCharArray(), $"Because digit nine is made from segments: {DisplayDigit.Create(9)}");
    }

    protected override DisplayExperiment InitializeExperiment(string _experiment) => DisplayExperimentV2.Parse(_experiment);
}