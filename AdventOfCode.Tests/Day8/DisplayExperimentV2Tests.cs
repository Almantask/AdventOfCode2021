using AdventOfCode.Day8;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day8;

public abstract class DisplayExperimentV2Tests : DisplayExperimentTests
{
    // Within experiment
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

    // Translated
    protected abstract char ExpectedSegmentA { get; }
    protected abstract char ExpectedSegmentB { get; }
    protected abstract char ExpectedSegmentC { get; }
    protected abstract char ExpectedSegmentD { get; }
    protected abstract char ExpectedSegmentE { get; }
    protected abstract char ExpectedSegmentF { get; }
    protected abstract char ExpectedSegmentG { get; }

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
            segmentC.Should().Be(ExpectedSegmentC, "Digit two overlaps with digit one at exactly 1 segment");
        }
    }

    [Fact]
    public void FindDigitFiveAndSegmentF_ReturnsExpected()
    {
        var (digitFiveSegments, segmentF) = _experiment.FindDigitFiveAndSegmentF(One.ToCharArray(), Four.ToCharArray());

        using (new AssertionScope())
        {
            digitFiveSegments.Should().BeEquivalentTo(Five.ToCharArray(), "Digit five overlaps with digit four at 3 segments.");
            segmentF.Should().Be(ExpectedSegmentF, "Digit five overlaps with digit one at exactly 1 segment");
        }
    }

    [Fact]
    public void FindSegmentA_ReturnsExpected()
    {
        var segmentA = _experiment.FindSegmentA(Seven.ToCharArray(), One.ToCharArray());

        segmentA.Should().Be(ExpectedSegmentA, "Digit seven compared to digit one has 1 extra segment");
    }

    [Fact]
    public void FindDigitThreeAndSegmentDAndSegmentB_ReturnsExpected()
    {
        var (digitThreeSegments, segmentD, segmentB) = _experiment.FindDigitThreeAndSegmentDAndSegmentB(One.ToCharArray(), Four.ToCharArray());

        using (new AssertionScope())
        {
            digitThreeSegments.Should().BeEquivalentTo(Three.ToCharArray(), "Digit four overlaps with digit three at a 1 extra segment");
            segmentD.Should().Be(ExpectedSegmentD, "Digit four overlaps with digit three at a 1 extra segment");
            segmentB.Should().Be(ExpectedSegmentB, "Knowing segment d - we're left with the last segment on digit four");
        }
    }

    [Fact]
    public void FindDigitSixAndSegmentE_ReturnsExpected()
    {
        var (digitSixSegments, segmentE) = _experiment.FindDigitSixAndSegmentE(Five.ToCharArray(), ExpectedSegmentC);

        using (new AssertionScope())
        {
            digitSixSegments.Should().BeEquivalentTo(Six.ToCharArray(), "Digit six overlaps in all segments but 1 with digit five");
            segmentE.Should().Be(ExpectedSegmentE, "Digit six overlaps in all segments but 1 with digit five");
        }
    }

    [Fact]
    public void FindSegmentG_ReturnsExpected()
    {
        var knownSegments = Eight.ToCharArray().Except(new[] { ExpectedSegmentG }).ToArray();

        var segmentG = _experiment.FindSegmentG(knownSegments);

        segmentG.Should().Be(ExpectedSegmentG, "G is the last missing segment");
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
        const string experimentString = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"; ;
        var experiment = DisplayExperimentV2.Parse(experimentString);

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

        var digitZeroSegments = experiment.FindDigit(digit, segmentsMap);

        digitZeroSegments.Should().BeEquivalentTo(expectedSegmentsText.ToCharArray());
    }

    protected override DisplayExperiment InitializeExperiment(string experiment) => DisplayExperimentV2.Parse(experiment);
    private string BuildExperimentString() => $"{Two} {Three} {Four} {One} {Zero} {Six} {Seven} {Eight} {Five} {Nine}| {Zero} {One} {One} {Five}";
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

    protected override char ExpectedSegmentA => 'd';
    protected override char ExpectedSegmentB => 'e';
    protected override char ExpectedSegmentC => 'a';
    protected override char ExpectedSegmentD => 'f';
    protected override char ExpectedSegmentE => 'g';
    protected override char ExpectedSegmentF => 'b';
    protected override char ExpectedSegmentG => 'c';
}

/*
 *
  0:      1:      2:      3:      4:
 aaaa    ....    aaaa    aaaa    ....
b    c  .    c  .    c  .    c  b    c
b    c  .    c  .    c  .    c  b    c
 ....    ....    dddd    dddd    dddd
e    f  .    f  e    .  .    f  .    f
e    f  .    f  e    .  .    f  .    f
 gggg    ....    gggg    gggg    ....

  5:      6:      7:      8:      9:
 aaaa    aaaa    aaaa    aaaa    aaaa
b    .  b    .  .    c  b    c  b    c
b    .  b    .  .    c  b    c  b    c
 dddd    dddd    ....    dddd    dddd
.    f  e    f  .    f  e    f  .    f
.    f  e    f  .    f  e    f  .    f
 gggg    gggg    ....    gggg    gggg
 */

public class DisplayExperimentV2Tests2 : DisplayExperimentV2Tests
{
    // be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
    protected override string Zero => "abdefg"; // abcefg = abdefg
    protected override string One => "be"; // +
    protected override string Two => "abcdf"; // c = b, f = e.
    protected override string Three => "bcdef"; // d= c, b = g.
    protected override string Four => "bceg"; // +
    protected override string Five => "cdefg"; // +
    protected override string Six => "acdefg"; // e = a
    protected override string Seven => "ebd"; // a = d.
    protected override string Eight => "abcdefg"; // +
    protected override string Nine => "bcdefg"; // abcdfg = bcdefg

    protected override char ExpectedSegmentA => 'd';
    protected override char ExpectedSegmentB => 'g';
    protected override char ExpectedSegmentC => 'b';
    protected override char ExpectedSegmentD => 'c';
    protected override char ExpectedSegmentE => 'a';
    protected override char ExpectedSegmentF => 'e';
    protected override char ExpectedSegmentG => 'f';
}