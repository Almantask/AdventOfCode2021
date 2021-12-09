namespace AdventOfCode.Day6;

public class Lanternfishes
{
    public const int DaysUntilFirstLanternfishSpawnAnother = 6;
    public const int DaysUntilChildLanternfishSpawnAnother = 8;

    public class Naive : ILanternfishes
    {
        private const int SpawningDay = -1;

        public int Count => _internalTimers.Count;

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
                if (_internalTimers[i] == SpawningDay)
                {
                    _internalTimers[i] = DaysUntilFirstLanternfishSpawnAnother;
                    newSpawns++;
                }
            }

            // Spawn new lanternfishes
            var newSpawnLanternfishes = Enumerable.Repeat(DaysUntilChildLanternfishSpawnAnother, newSpawns);
            _internalTimers.AddRange(newSpawnLanternfishes);
        }
    }

    public class Optimal : ILanternfishes
    {
        public const int DaysUntilFirstLanternfishSpawnAnother = 6;
        public const int DaysUntilChildLanternfishSpawnAnother = 8;
        private const int SpawningDay = -1;

        public int Count => _internalTimers.Count;

        private readonly Dictionary<int, long> _internalTimers;

        public Optimal(params int[] internalTimers)
        {
            _internalTimers = new Dictionary<int, long>()
            {
                { 0, 0 },
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 },
                { 7, 0 },
                { 8, 0 }
            };

            foreach (var timer in internalTimers)
            {
                _internalTimers[timer]++;
            }
        }

        public void SimulateOneDay()
        {
            //var newSpawns = 0;
            //// Decrement internal timers
            //for (int i = 0; i < _internalTimers.Count; i++)
            //{
            //    _internalTimers[i]--;
            //    if (_internalTimers[i] == SpawningDay)
            //    {
            //        _internalTimers[i] = DaysUntilFirstLanternfishSpawnAnother;
            //        newSpawns++;
            //    }
            //}

            //// Spawn new lanternfishes
            //var newSpawnLanternfishes = Enumerable.Repeat(DaysUntilChildLanternfishSpawnAnother, newSpawns);
            //_internalTimers.AddRange(newSpawnLanternfishes);
        }
    }
}