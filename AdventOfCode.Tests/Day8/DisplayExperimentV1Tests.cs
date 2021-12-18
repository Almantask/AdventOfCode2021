using AdventOfCode.Day8;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day8;

public class DisplayExperimentV1Tests : DisplayExperimentTests
{
    [Fact]
    public void FindDigitOne_ReturnsIndexOf1InTheOutput()
    {
        //                                                                                                    index of 1: 3|
        //                                                                                                                v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb ab";
        var experiment = DisplayExperimentV1.Parse(standardExperiment);

        var indexOf1 = experiment.FindDigitOne();

        indexOf1.Should().Be(3);
    }

    [Fact]
    public void FindDigitFour_ReturnsIndexOf4InTheOutput()
    {
        //                                                                                               index of 4: 2|
        //                                                                                                            v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb eafb cdbaf";
        var experiment = DisplayExperimentV1.Parse(standardExperiment);

        var indexOf4 = experiment.FindDigitFour();

        indexOf4.Should().Be(2);
    }

    [Fact]
    public void FindDigitSeven_ReturnsIndexOf7InTheOutput()
    {
        //                                                                                       index of 7: 1|
        //                                                                                                    v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb dab cdfeb cdbaf";
        var experiment = DisplayExperimentV1.Parse(standardExperiment);

        var indexOf4 = experiment.FindDigitSeven();

        indexOf4.Should().Be(1);
    }

    [Fact]
    public void FindDigitEight_ReturnsIndexOf8InTheOutput()
    {
        //                                                                                   index of 8: 0|
        //                                                                                                v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | acedgfb fcadb cdfeb cdbaf";
        var experiment = DisplayExperimentV1.Parse(standardExperiment);

        var indexOf4 = experiment.FindDigitEight();

        indexOf4.Should().Be(0);
    }

    protected override DisplayExperiment InitializeExperiment(string experiment) => DisplayExperimentV1.Parse(experiment);
}