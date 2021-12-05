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

        public class PowerConsumption
        {
            [Fact]
            public void Returns_Epsilon_MultipliedBy_Gamma()
            {
                var binaryNumbers = new[,]
                {
                    {'1', '1', '1', '1', '1'},
                    {'0', '1', '1', '1', '1'}
                };
                var diagnosticReport = new DiagnosticReport(binaryNumbers);

                var powerConsumption = diagnosticReport.PowerConsumption;

                powerConsumption.Should().Be(diagnosticReport.EpsilonRate * diagnosticReport.GammaRate);
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
                var diagnosticReport = new DiagnosticReport(binaryNumbers);
                var expectedMostCommonVertical = new[] { '0', '0', '1', '1', '1' };

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

        public class LifeSupportRating
        {
            [Fact]
            public void Returns_OxygenGeneratorRating_MultipliedBy_Co2ScrubberRating()
            {
                var binaryNumbers = new[,]
                {
                    {'1', '1', '1', '1', '1'},
                    {'0', '1', '1', '1', '1'},
                };

                var diagnosticReport = new DiagnosticReportV2(binaryNumbers);

                var mostCommonVertical = diagnosticReport.LifeSupportRating;

                mostCommonVertical.Should().Be(diagnosticReport.OxygenGeneratorRating * diagnosticReport.Co2ScrubberRating);
            }
        }

        public class OxygenRating
        {
            [Theory]
            [MemberData(nameof(OxygenGeneratorRatingExpectations))]
            public void Returns_OxygenGeneratorRating(char[,] binaryNumbers, long expectedOxygenGeneratorRating)
            {
                var diagnosticReport = new DiagnosticReportV2(binaryNumbers);

                var oxygenGeneratorRating = diagnosticReport.OxygenGeneratorRating;

                oxygenGeneratorRating.Should().Be(expectedOxygenGeneratorRating);
            }

            public static IEnumerable<object[]> OxygenGeneratorRatingExpectations
            {
                get
                {
                    // Keep the lines with the more common bit at vertical position
                    // If same count of 1s and 0s - take 1s
                    // Move on to the next bit at horizontal position
                    // Repeat until 1 number is left
                    // Convert that number to decimal
                    yield return new object[]
                    {
                        new[,]
                        {
                            {'0', '1'}, // 1st
                            {'1', '1'},
                            {'0', '0'}, // 1st
                            {'1', '0'}  // 2nd
                        },
                        3
                    };

                    yield return new object[]
                    {
                        new[,]
                        {
                            {'0', '1', '0'}, // 1st
                            {'1', '1', '1'},
                            {'0', '0', '0'}, // 1st
                            {'1', '1', '0'}  // 3rd
                        },
                        7
                    };

                    yield return new object[]
                    {
                        new[,]
                        {
                            {'1', '1', '1', '1', '1'}, // 1st
                            {'0', '1', '1', '1', '1'}, // 2nd
                            {'0', '0', '1', '1', '1'}, // 3rd
                            {'0', '0', '0', '1', '1'},
                            {'0', '0', '0', '0', '1'}  // 4th
                        },
                        3
                    };
                }
            }
        }

        public class Co2ScrubberRating
        {
            [Theory]
            [MemberData(nameof(Co2ScrubberRatingExpectations))]
            public void Returns_Co2ScrubberRating(char[,] binaryNumbers, long expectedCo2ScrubberRating)
            {
                var diagnosticReport = new DiagnosticReportV2(binaryNumbers);

                var co2ScrubberRating = diagnosticReport.Co2ScrubberRating;

                co2ScrubberRating.Should().Be(expectedCo2ScrubberRating);
            }

            public static IEnumerable<object[]> Co2ScrubberRatingExpectations
            {
                get
                {
                    // Keep the lines with the less common bit at horizontal position
                    // If same count of 1s and 0s - take 0s
                    // Move on to the next bit (vertical)
                    // Repeat until 1 number is left
                    // Convert that number to decimal
                    yield return new object[]
                    {
                        new[,]
                        {
                            {'0', '1'}, // 2nd
                            {'1', '1'}, // 1st
                            {'0', '0'},
                            {'1', '0'}  // 1st
                        },
                        0
                    };

                    yield return new object[]
                    {
                        new[,]
                        {
                            {'0', '1', '0'}, // 2nd
                            {'1', '1', '1'}, // 1st
                            {'0', '0', '0'},
                            {'1', '1', '0'}  // 1st
                        },
                        0
                    };

                    yield return new object[]
                    {
                        new[,]
                        {
                            {'1', '1', '1', '1', '1'},
                            {'0', '1', '1', '1', '1'}, // 1st
                            {'0', '0', '1', '1', '1'}, // 1st
                            {'0', '0', '0', '1', '1'}, // 1st
                            {'0', '0', '0', '0', '1'}, // 1st
                        },
                        31
                    };
                }
            }
        }

    }
}
