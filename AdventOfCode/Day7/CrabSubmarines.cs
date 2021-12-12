using AdventOfCode.Common;

namespace AdventOfCode.Day7
{
    public class CrabSubmarines
    {
        private readonly int[] _submarineHorizontalPositions;

        public CrabSubmarines(int[] submarineHorizontalPositions)
        {
            _submarineHorizontalPositions = submarineHorizontalPositions;
        }

        public int GetOptimalAlginment()
        {
            return (int)Math.Ceiling(_submarineHorizontalPositions.FindMedian());
        }

        public long CalculateFuelCostTo(int horizontalPosition)
        {
            return _submarineHorizontalPositions.Sum(s => Math.Abs(s - horizontalPosition));
        }
    }
}
