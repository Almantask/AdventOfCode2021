namespace AdventOfCode.Day4;

public class Bingo
{
    protected Table[] Tables { get; }
    protected byte[] NumbersToDraw { get; }

    public Bingo(Table[] tables, byte[] numbersToDraw)
    {
        Tables = tables;
        NumbersToDraw = numbersToDraw;
    }

    /// <summary>
    /// Gets winner score or null if no winner is yet found.
    /// </summary>
    public virtual long? GetWinnersScore()
    {
        foreach (var table in Tables)
        {
            if (table.IsWinner()) return table.CalculateScore();
        }

        return null;
    }

    public virtual void Play()
    {
        foreach (var numberToDraw in NumbersToDraw)
        {
            Draw(numberToDraw);
            if (AnyWinners()) return;
        }
    }

    protected void Draw(byte number)
    {
        foreach (var table in Tables)
        {
            table.MarkNumber(number);
        }
    }

    private bool AnyWinners()
    {
        foreach (var table in Tables)
        {
            if (table.IsWinner()) return true;
        }

        return false;
    }
}