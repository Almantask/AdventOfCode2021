namespace AdventOfCode.Tests.Day6;

public class Lanternfishes
{
    public const int DaysUntilFirstLanternfishSpawnAnother = 6;
    public const int DaysUntilChildLanternfishSpawnAnother = 8;
    private const int SpawningDay = -1;

    public int Count => _internalTimers.Count;

    private readonly List<int> _internalTimers;

    public Lanternfishes(params int[] internalTimers)
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