namespace AdventOfCode.Day4;

public class RiggedBingo : Bingo
{
    public RiggedBingo(Table[] tables, byte[] numbersToDraw) : base(tables, numbersToDraw)
    {
    }

    public override long? GetWinnersScore()
    {
        var lastWinner = Tables.MaxBy(t => t.DrawnNumbersCount);
        var lasWinnerScore = lastWinner.CalculateScore();

        return lasWinnerScore;
    }

    public override void Play()
    {
        foreach (var numberToDraw in NumbersToDraw)
        {
            Draw(numberToDraw);
            FlagWinners();
        }
    }

    private void FlagWinners()
    {
        foreach (var table in Tables)
        {
            table.IsWinner();
        }
    }
}