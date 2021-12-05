using AdventOfCode.Day4;

namespace AdventOfCode.Tests.Day4
{
    public class TableTests
    {
        [Theory]
        [MemberData(nameof(IsWinnerExpectations))]
        public void IsWinner_Returns_Whether_AllNumbersInTheSameRow_OrColumn_AreMarked(byte[,] board, byte[] draws, bool expectedIsWinner)
        {
            var table = new Table(board);
            SimulateDraws(table, draws);

            var isWinner = table.IsWinner();

            isWinner.Should().Be(expectedIsWinner);
        }

        [Fact]
        public void Score_Returns_SumOfAllUnmarkedNumbers_MultipliedByWinningNumber()
        {
            var board = new byte[,]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                { 21, 22, 23, 24, 25 },
            };
            var draws = new byte[] { 1, 2, 3, 4, 5 };
            var table = new Table(board);
            const long expectedSum = 310 * 5;
            SimulateDraws(table, draws);

            var score = table.CalculateScore();

            score.Should().Be(expectedSum);
        }

        private static void SimulateDraws(Table table, byte[] draws)
        {
            foreach (var draw in draws)
            {
                table.MarkNumber(draw);
            }
        }

        public static IEnumerable<object[]> IsWinnerExpectations
        {
            get
            {

                var firstRowWins = new object[]
                {
                    new byte[,]
                    {
                        {1, 2, 3, 4 , 5}, // <- winner
                        {6, 7, 8, 9 , 10},
                        {11, 12, 13, 14 , 15},
                        {16, 17, 18, 19 , 20},
                        {21, 22, 23, 24 , 25},
                    },
                    new byte[] {1, 2, 3, 4 , 5},
                    true
                };
                yield return firstRowWins;


                var noDrawsNoWin = new object[]
                {
                    new byte[,]
                    {
                        {1, 2, 3, 4 , 5},
                        {6, 7, 8, 9 , 10},
                        {11, 12, 13, 14 , 15},
                        {16, 17, 18, 19 , 20},
                        {21, 22, 23, 24 , 25},
                    },
                    new byte[] {},
                    false
                };
                yield return noDrawsNoWin;

                var almostRowAlmostColumnNoWin = new object[]
                {
                    new byte[,]
                    {
                        {1, 2, 3, 4, 5},
                        {6, 7, 8, 9, 10},
                        {11, 12, 13, 14 , 15},
                        {16, 17, 18, 19 , 20},
                        {21, 22, 23, 24 , 25},
                    },
                    new byte[] {1, 2, 3, 4, 6, 11, 16},
                    false
                };
                yield return almostRowAlmostColumnNoWin;

                var firstColumnWins = new object[]
                {
                    new byte[,]
                    {
                 // winner
                 //      |
                 //      v
                        {1, 2, 3, 4, 5},
                        {6, 7, 8, 9, 10},
                        {11, 12, 13, 14 , 15},
                        {16, 17, 18, 19 , 20},
                        {21, 22, 23, 24 , 25},
                    },
                    new byte[] {1, 2, 6, 11, 16, 3, 21},
                    true
                };
                yield return firstColumnWins;
            }
        }
    }
}
