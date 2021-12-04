using AdventOfCode.Day3;

namespace AdventOfCode.Tests.Day3
{
    public class DiagnosticReportTests
    {
        public class GammaRate
        {
            [Theory]
            [MemberData(nameof(ExpectedGammaRates))]
            public void ReturnsDecimalOfMostCommonBitAtVertical(char[,] binaryNumbers, long expectedGammaRate)
            {
                var diagnosticReport = new DiagnosticReport(binaryNumbers);

                var gammaRate = diagnosticReport.GammaRate;

                gammaRate.Should().Be(expectedGammaRate);
            }

            public static IEnumerable<object[]> ExpectedGammaRates
            {
                get
                {
                    yield return new object[]
                    {
                        new [,]
                        {
                            { '0', '1', '1' },
                            { '0', '1', '1' },
                        },
                        3
                    };
                    yield return new object[]
                    {
                        new [,]
                        {
                            { '1', '0', '0' },
                            { '1', '0', '0' },
                        },
                        4
                    };
                    yield return new object[]
                    {
                        new [,]
                        {
                            { '1', '1' },
                            { '1', '0' },
                            { '0', '1' },
                            { '1', '1' },
                        },
                        3
                    };
                    // Assume the bits don't repeat the same amount of times.
                }
            }
        }

        public class EpsilonRate
        {
            [Theory]
            [MemberData(nameof(ExpectedEpsilonRates))]
            public void ReturnsDecimalOfLeastCommonBitAtVertical(char[,] binaryNumbers, long expectedEpsilonRate)
            {
                var diagnosticReport = new DiagnosticReport(binaryNumbers);

                var epsilonRate = diagnosticReport.EpsilonRate;

                epsilonRate.Should().Be(expectedEpsilonRate);
            }

            public static IEnumerable<object[]> ExpectedEpsilonRates
            {
                get
                {
                    yield return new object[]
                    {
                        new [,]
                        {
                            { '0', '1', '1' },
                            { '0', '1', '1' },
                        },
                        4
                    };
                    yield return new object[]
                    {
                        new [,]
                        {
                            { '1', '0', '0' },
                            { '1', '0', '0' },
                        },
                        3
                    };
                    yield return new object[]
                    {
                        new [,]
                        {
                            { '1', '1' },
                            { '1', '0' },
                            { '0', '1' },
                            { '1', '1' },
                        },
                        0
                    };
                    // Assume the bits don't repeat the same amount of times.
                }
            }
        }

        public class MostCommonVertical
        {
            [Fact]
            public void ReturnsMostCommonBitAtEachVertical()
            {
                var binaryNumbers = new[,]
                {
                    {'1', '1', '1', '1', '1'},
                    {'0', '1', '1', '1', '1'},
                    {'0', '0', '1', '1', '1'},
                    {'0', '0', '0', '1', '1'},
                    {'0', '0', '0', '0', '1'}
                };
                var expectedMostCommonVertical = new[] { '0', '0', '1', '1', '1' };

                var diagnosticReport = new DiagnosticReport(binaryNumbers);

                var mostCommonVertical = diagnosticReport.MostCommonVertical;

                mostCommonVertical.Should().BeEquivalentTo(expectedMostCommonVertical);
            }

            [Fact]
            public void WhenNotBits_ThrowsArgumentException()
            {
                var notBits = new[,]
                {
                    {'a'}
                };

                Action newDiagnosticReportContainingNotBits = () => new DiagnosticReport(notBits);

                newDiagnosticReportContainingNotBits
                    .Should().Throw<ArgumentException>()
                    .Which.ParamName.Should().Be("bit");
            }
        }
    }
}
