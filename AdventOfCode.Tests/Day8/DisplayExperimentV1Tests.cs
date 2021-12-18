using AdventOfCode.Day8;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day8;

public class DisplayExperimentV1Tests : DisplayExperimentTests
{
    [Fact]
    public void Find1_ReturnsIndexOf1InTheOutput()
    {
        //                                                                             index of 1: 9|
        //                                                                                          v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb ab";
        var experiment = DisplayExperimentV1.Parse(standardExperiment);

        var indexOf1 = experiment.Find1();

        indexOf1.Should().Be(3);
    }

    [Fact]
    public void Find4_ReturnsIndexOf4InTheOutput()
    {
        //                                                                                               index of 4: 7|
        //                                                                                                            v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb eafb cdbaf";
        var experiment = DisplayExperimentV1.Parse(standardExperiment);

        var indexOf4 = experiment.Find4();

        indexOf4.Should().Be(2);
    }

    [Fact]
    public void Find7_ReturnsIndexOf7InTheOutput()
    {
        //                                                                                       index of 7: 4|
        //                                                                                                    v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb dab cdfeb cdbaf";
        var experiment = DisplayExperimentV1.Parse(standardExperiment);

        var indexOf4 = experiment.Find7();

        indexOf4.Should().Be(1);
    }

    [Fact]
    public void Find8_ReturnsIndexOf8InTheOutput()
    {
        //                                                                                   index of 8: 0|
        //                                                                                                v
        const string standardExperiment = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | acedgfb fcadb cdfeb cdbaf";
        var experiment = DisplayExperimentV1.Parse(standardExperiment);

        var indexOf4 = experiment.Find8();

        indexOf4.Should().Be(0);
    }

    protected override DisplayExperiment InitializeExperiment(string experiment) => DisplayExperimentV1.Parse(experiment);
}