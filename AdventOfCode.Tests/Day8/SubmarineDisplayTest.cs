using AdventOfCode.Day8;

namespace AdventOfCode.Tests.Day8
{
    public class SubmarineDisplayTests
    {
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

        [Theory]
        [InlineData($"{Two} {Three} {Four} {One} {Zero} {Six} {Seven} {Eight} {Five} {Nine}| {Zero} {One} {One} {Five}", 115)]
        [InlineData($"{Four} {Three} {Two} {One} {Zero} {Six} {Seven} {Eight} {Five} {Nine}| {One} {Two} {Three} {Four}", 1234)]
        [InlineData($"{Two} {Three} {Four} {One} {Zero} {Six} {Seven} {Eight} {Five} {Nine}| {Five} {Six} {Seven} {Eight}", 5678)]
        [InlineData($"{Two} {Three} {Four} {One} {Zero} {Six} {Seven} {Eight} {Five} {Nine}| {Nine} {Nine} {Nine} {Nine}", 9999)]
        [InlineData($"{Two} {Three} {Four} {One} {Zero} {Six} {Seven} {Eight} {Five} {Nine}| ecfbad ecdbaf dcfbae eafbcd", 9999)]
        public void Output_ReturnsDecoded(string experimentText, int expectedOutput)
        {
            var experiment = DisplayExperimentV2.Parse(experimentText);
            var display = new SubmarineDisplay(experiment);

            display.Output.Should().Be(expectedOutput);
        }
    }
}
