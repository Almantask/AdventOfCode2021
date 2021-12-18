using AdventOfCode.Day8;

namespace AdventOfCode.Tests.Day8;

public class DisplayExperimentV2Tests : DisplayExperimentTests
{
    // Different digits will have overlapping lit segments.
    // This can be used to deduce which actual segments are lit.

    // 1, 4, 7 and 8 - known.

    // 1 is our start. Use 2 and 5 to deduce exact positions (because they overlap at exactly one place).
    // c, f - known.
    // 1, **2**, 4, **5**, 7, 8 - known.

    // 7 is next up and is an easy one (because there is only 1 extra segment) and it has unique segments count.
    // **a**, c, f - known.
    // 1, 2, 4, 5, 7, 8 - known.

    // We will analyze 4 next (last number with unique count). b and d are unknown.
    // 5 is the only number that has 2 segments off and overlaps with a 4 at a single place - b.
    // The remaining segment in 4 is d.
    // a, **b**, c, **d**, f - known.
    // 1, 2, 4, 5, 7, 8 - known.

    // 6 overlaps in all places but 1 with 5. The non-overlapping segment - e.
    // a, b, c, d, **e**, f - known.
    // 1, 2, 4, 5, **6**, 7, 8 - known.

    // The last missing segment is g. With it, we can deduce the remaining numbers.
    // a, b, c, d, e, f, **g** - known.
    // **0**, 1, 2, **3**, 4, 5, 6, 7, 8, **9** - known.

    #region Known Numbers

    [Fact]
    public void FindDigitOne_ReturnsIndexOf1In10Signals()
    {
        //                                                                             index of 1: 9|
        //                                                                                          v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb ab";
        var experiment = DisplayExperimentV2.Parse(standardExperiment);

        var indexOf1 = experiment.FindDigitOne();

        indexOf1.Should().Be(9);
    }

    [Fact]
    public void FindDigitFour_ReturnsIndexOf4In10Signals()
    {
        //                                                                 index of 4: 7|
        //                                                                              v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb eafb cdbaf";
        var experiment = DisplayExperimentV2.Parse(standardExperiment);

        var indexOf4 = experiment.FindDigitFour();

        indexOf4.Should().Be(7);
    }

    [Fact]
    public void FindDigitSeven_ReturnsIndexOf7In10Signals()
    {
        //                                               index of 7: 4|
        //                                                            v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb dab cdfeb cdbaf";
        var experiment = DisplayExperimentV2.Parse(standardExperiment);

        var indexOf4 = experiment.FindDigitSeven();

        indexOf4.Should().Be(4);
    }

    [Fact]
    public void FindDigitEight_ReturnsIndexOf8In10Signals()
    {
        //                        index of 8: 0|
        //                                     v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | acedgfb fcadb cdfeb cdbaf";
        var experiment = DisplayExperimentV2.Parse(standardExperiment);

        var indexOf4 = experiment.FindDigitEight();

        indexOf4.Should().Be(0);
    }

    #endregion

    [Fact]
    public void FindDigit2AndSegmentC_ReturnsIndexOf2AndCIn10Signals()
    {
        //                        index of 8: 0|
        //                                     v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | acedgfb fcadb cdfeb cdbaf";
        var experiment = DisplayExperimentV2.Parse(standardExperiment);

        var indexOf4 = experiment.FindDigitEight();

        indexOf4.Should().Be(0);
    }

    protected override DisplayExperiment InitializeExperiment(string experiment) => DisplayExperimentV2.Parse(experiment);
}