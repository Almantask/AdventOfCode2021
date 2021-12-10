using AdventOfCode.Common;

namespace AdventOfCode.Day6;

public class Lanternfishes
{
    public const int OldFishPool = 6;
    public const int NewFishPool = 8;

    public class Naive : ILanternfishes
    {
        public long Count => _internalTimers.Count;

        private readonly List<int> _internalTimers;

        public Naive(params int[] internalTimers)
        {
            _internalTimers = internalTimers.ToList();
        }

        public void SimulateOneDay()
        {
            var newSpawns = 0;
            // Decrement internal timers
            for (int i = 0; i < _internalTimers.Count; i++)
            {
                _internalTimers[i]--;
                const int SpawningDay = -1;
                if (_internalTimers[i] == SpawningDay)
                {
                    _internalTimers[i] = OldFishPool;
                    newSpawns++;
                }
            }

            // Spawn new lanternfishes
            var newSpawnLanternfishes = Enumerable.Repeat(NewFishPool, newSpawns);
            _internalTimers.AddRange(newSpawnLanternfishes);
        }
    }

    public class Optimal : ILanternfishes
    {
        private const int TotalPools = NewFishPool + 1;

        private const int SpawningDay = -1;

        public long Count => _internalTimersCounts.Sum();

        private readonly long[] _internalTimersCounts;

        public Optimal(params int[] internalTimers)
        {
            // Timer starts at 8, but ends AFTER 0.
            _internalTimersCounts = new long[TotalPools];

            foreach (var timer in internalTimers)
            {
                _internalTimersCounts[timer]++;
            }
        }

        public void SimulateOneDay()
        {
            // Split fishes into 9 pools, one for each counter.
            // Each day, fishes move from one pool to another.
            // When their counter hits 0 - they spawn a new fish (so extra fishes go to pool 8),
            // while others go back to pool 6 (start pool).

            // Fishes to spawn are at pool 0.
            var fishesToSpawn = _internalTimersCounts[0];

            // Decrement timers: so shift array elements by 1
            _internalTimersCounts.ShiftBy1ToLeft();

            _internalTimersCounts[OldFishPool] += fishesToSpawn;
        }
    }
}