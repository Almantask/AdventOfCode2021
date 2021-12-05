namespace AdventOfCode.Day4;

public class Table
{
    public long Score
    {
        get
        {
            var totalScore = 0;

            for (var vertical = 0; vertical < _board.GetLength(0); vertical++)
            {
                for (var horizontal = 0; horizontal < _board.GetLength(1); horizontal++)
                {
                    var isMarked = _markedNumbers[vertical, horizontal];
                    if (!isMarked)
                    {
                        totalScore += _board[vertical, horizontal];
                    }
                }
            }

            var winningNumber = _drawnNumbers.LastOrDefault();
            totalScore *= winningNumber;

            return totalScore;
        }
    }

    private readonly byte[,] _board;

    private readonly bool[,] _markedNumbers;

    private readonly IList<byte> _drawnNumbers;

    public Table(byte[,] board)
    {
        _board = board;
        const int BoardSize = 5;
        _markedNumbers = new bool[BoardSize, BoardSize];
        _drawnNumbers = new List<byte>();
    }

    public void MarkNumber(byte numberDrawn)
    {
        _drawnNumbers.Add(numberDrawn);

        for (var vertical = 0; vertical < _board.GetLength(0); vertical++)
        {
            for (var horizontal = 0; horizontal < _board.GetLength(1); horizontal++)
            {
                var numberOnBoard = _board[vertical, horizontal];
                if (numberOnBoard == numberDrawn)
                {
                    _markedNumbers[vertical, horizontal] = true;
                    return;
                }
            }
        }
    }

    public bool IsWinner()
    {
        var isAnyRowWinner = IsWinningRow();
        var isAnyColumnWinner = IsWinningColumn();

        return isAnyRowWinner || isAnyColumnWinner;

        bool IsWinningRow()
        {
            for (var vertical = 0; vertical < _markedNumbers.GetLength(0); vertical++)
            {
                if (IsWinningRow(vertical)) return true;
            }

            bool IsWinningRow(int row)
            {
                bool isWinner = true;
                for (var horizontal = 0; horizontal < _markedNumbers.GetLength(1); horizontal++)
                {
                    isWinner = isWinner && _markedNumbers[row, horizontal];
                }

                return isWinner;
            }

            return false;
        }

        bool IsWinningColumn()
        {
            for (var horizontal = 0; horizontal < _markedNumbers.GetLength(1); horizontal++)
            {
                if (IsWinningColumn(horizontal)) return true;
            }

            bool IsWinningColumn(int column)
            {
                var isWinner = true;
                for (var vertical = 0; vertical < _markedNumbers.GetLength(0); vertical++)
                {
                    isWinner = isWinner && _markedNumbers[vertical, column];
                }

                return isWinner;
            }

            return false;
        }
    }
}