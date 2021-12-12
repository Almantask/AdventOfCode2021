using AdventOfCode.Common;

namespace AdventOfCode.Day7
{
    public class CrabSubmarinesV2 : ICrabSubmarines
    {
        private readonly int[] _submarineHorizontalPositions;

        public CrabSubmarinesV2(int[] submarineHorizontalPositions)
        {
            _submarineHorizontalPositions = submarineHorizontalPositions;
        }

        public int GetOptimalAlginment()
        {
            // Optimal position should be an average.
            var optimal = (int)Math.Ceiling(_submarineHorizontalPositions.Average());
            // If it's not average, at least it is very close to it. 
            // This function moves closer to the exact optimal spot.
            return GetOptimalInternal(optimal);

            int GetOptimalInternal(int optimalGuess)
            {
                // Could use a dictionary for optimized results...
                var fuelCostOptimalGuess = CalculateFuelCostTo(optimalGuess);
                var fuelCostForOneHigher = CalculateFuelCostTo(optimalGuess + 1);
                var fuelCostForOneLower = CalculateFuelCostTo(optimalGuess - 1);
                int nextOptimal;
                long lowerOne;
                if (fuelCostForOneLower < fuelCostForOneHigher)
                {
                    nextOptimal = optimalGuess - 1;
                    lowerOne = fuelCostForOneLower;
                }
                else
                {
                    nextOptimal = optimalGuess + 1;
                    lowerOne = fuelCostForOneHigher;
                }
                if (fuelCostOptimalGuess <= lowerOne) return optimalGuess;
                return GetOptimalInternal(nextOptimal);
            }
        }

        public long CalculateFuelCostTo(int horizontalPosition)
        {
            return _submarineHorizontalPositions.Sum(s =>
            {
                // Moving submarine forms arithmetic progression.
                var distance = Math.Abs(s - horizontalPosition);
                return SumArithmeticProgression(
                    // First position to move costs 1.
                    1,
                    // Last one costs the total distance to travel (because fuel cost increases by 1).
                    distance,
                    // Distance determines how many steps we will need to move - how many elements in an arithmetic sequence.
                    distance
                );

            });

            int SumArithmeticProgression(int start, int end, int count)
                => (int)((start + end) / 2.0 * count);
        }
    }

    public class CrabSubmarinesV1 : ICrabSubmarines
    {
        private readonly int[] _submarineHorizontalPositions;

        public CrabSubmarinesV1(int[] submarineHorizontalPositions)
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
