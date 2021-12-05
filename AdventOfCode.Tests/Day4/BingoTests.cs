using AdventOfCode.Day4;

namespace AdventOfCode.Tests.Day4
{
    public class BingoTests
    {
        [Theory]
        [MemberData(nameof(GetWinnerScoreNoWinnerExpectations))]
        public void GetWinnersScore_GivenNoWinner_ReturnsNull(Table[] tables, byte[] draws)
        {
            var bingo = new Bingo(tables, draws);
            bingo.Play();

            var winnersScore = bingo.GetWinnersScore();

            winnersScore.Should().BeNull();
        }

        [Theory]
        [MemberData(nameof(GetWinnerScoreWinnerExpectations))]
        public void GetWinnersScore_Given1Winner_ReturnsWinnersScore(Table[] tables, byte[] draws, long expectedScore)
        {
            var bingo = new Bingo(tables, draws);
            bingo.Play();

            var winnersScore = bingo.GetWinnersScore();

            winnersScore.Should().Be(expectedScore);
        }

        public static IEnumerable<object[]> GetWinnerScoreWinnerExpectations
        {
            get
            {
                var firstBoardFirstRowWins = new object[]
                {
                    new []
                    {
                        new Table(new byte[,]
                        {
                            {1, 2, 3, 4 , 5}, // <- Winner
                            {6, 7, 8, 9 , 10},
                            {11, 12, 13, 14 , 15},
                            {16, 17, 18, 19 , 20},
                            {21, 22, 23, 24 , 25}
                        }),
                        new Table(new byte[,]
                        {
                            {1, 4, 3, 33, 5},
                            {6, 7, 8, 9 , 10},
                            {11, 12, 13, 14 , 15},
                            {16, 17, 18, 19 , 20},
                            {21, 22, 23, 24 , 25}
                        })
                    },
                    new byte[] {1, 2, 3, 4 , 5},
                    310 * 5
                };
                yield return firstBoardFirstRowWins;

                var secondBoardThirdColumnWins = new object[]
                {
                    new []
                    {
                        new Table(new byte[,]
                        {
                            {1, 2, 3, 4, 5},
                            {6, 7, 8, 9, 10},
                            {11, 66, 13, 99, 15},
                            {16, 17, 18, 19, 20},
                            {21, 22, 23, 24, 25}
                        }),
                        new Table(new byte[,]
                        {
                          // Winner
                          // |
                          // v
                            {1, 2, 3, 4, 5},
                            {6, 7, 8, 9, 10},
                            {11, 12, 13, 66, 14},
                            {88, 17, 18, 19, 20},
                            {77, 22, 23, 24, 25}
                        })
                    },
                    new byte[] {1, 2, 6, 11, 88, 77},
                    319 * 77
                };
                yield return secondBoardThirdColumnWins;
            }
        }

        public static IEnumerable<object[]> GetWinnerScoreNoWinnerExpectations
        {
            get
            {
                var noDrawsNoWin = new object[]
                {
                    new []
                    {
                        new Table(new byte[,]
                        {
                            {1, 2, 3, 4 , 5},
                            {6, 7, 8, 9 , 10},
                            {11, 12, 13, 14 , 15},
                            {16, 17, 18, 19 , 20},
                            {21, 22, 23, 24 , 25},
                        })
                    },
                    new byte[] {}
                };
                yield return noDrawsNoWin;

                var almostRowAlmostColumnNoWin = new object[]
                {
                    new []
                    {
                        new Table(new byte[,]
                        {
                            {1, 2, 3, 4, 5},
                            {6, 7, 8, 9, 10},
                            {11, 12, 13, 14 , 15},
                            {16, 17, 18, 19 , 20},
                            {21, 22, 23, 24 , 25},
                        })
                    },
                    new byte[] {1, 2, 3, 4, 6, 11, 16}
                };
                yield return almostRowAlmostColumnNoWin;
            }
        }
    }
}