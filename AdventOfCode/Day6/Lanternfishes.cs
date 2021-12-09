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

        private readonly int[] _internalTimersCounts;

        public Optimal(params int[] internalTimers)
        {
            // Timer starts at 8, but ends AFTER 0.
            _internalTimersCounts = new int[TotalPools];

            foreach (var timer in internalTimers)
            {
                _internalTimersCounts[timer]++;
            }
        }

        public void SimulateOneDay()
        {
            // Split fishes into 9 pools, one for each counter.
            // Each day, fishes move from one pool to another.
            // When their counter hits 0 - they spawn a new fish.
            // Counter of a new fish is 8.
            // Counter of an old fish which split is 6.

            var fishesToSpawn = _internalTimersCounts[0];

            // So shift array elements by 1

            // And add fishes to spawn

        }

        private void IncrementTimers()
        {
            var newTimers = new int[TotalPools];
            for (var currentPool = 0; currentPool < TotalPools; currentPool++)
            {
                int previousPool;
                //if ()
                //{
                //    previousPool = 8;
                //}
                //else
                //{

                //}
                newTimers[currentPool - 1)]
            }
        }
    }
}