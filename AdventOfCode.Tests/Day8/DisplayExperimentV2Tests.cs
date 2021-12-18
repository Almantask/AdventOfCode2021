using AdventOfCode.Day8;

namespace AdventOfCode.Tests.Day8;

public class DisplayExperimentV2Tests : DisplayExperimentTests
{
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