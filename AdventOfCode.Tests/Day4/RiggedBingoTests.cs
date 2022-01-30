using AdventOfCode.Day4;

namespace AdventOfCode.Tests.Day4
{
    public class RiggedBingoTests
    {
        [Theory]
        [MemberData(nameof(GetWinnerScoreLastWinnerExpectations))]
        public void GetWinnersScore_Given1Winner_ReturnsWinnersScore(Table[] tables, byte[] draws, long expectedScore)
        {
            var bingo = new RiggedBingo(tables, draws);
            bingo.Play();

            var winnersScore = bingo.GetWinnersScore();

            winnersScore.Should().Be(expectedScore);
        }

        public static IEnumerable<object[]> GetWinnerScoreLastWinnerExpectations
        {
            get
            {
                var firstBoardFirstColumnWinsLast = new object[]
                {
                    new []
                    {
                        new Table(new byte[,]
                        {
              // Last winner |
              //             v
                            {1, 2, 3, 4, 55},
                            {6, 7, 8, 9, 10},
                            {11, 66, 13, 99, 15},
                            {16, 17, 18, 19, 20},
                            {21, 22, 23, 24, 25}
                        }),
                        new Table(new byte[,]
                        {
                            {1, 2, 3, 4, 6},
                            {33, 7, 8, 9, 10},
                            {11, 12, 13, 66, 14},
                            {88, 17, 18, 19, 20},
                            {77, 22, 23, 24, 25}
                        })
                    },
                    new byte[] {1, 2, 3, 4, 5, 21, 6, 11, 16, 99},
                    450 * 16
                };
                yield return firstBoardFirstColumnWinsLast;
            }
        }
    }
}