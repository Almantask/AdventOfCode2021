using AdventOfCode.Day6;

namespace AdventOfCode.Tests.Day6
{
    public class NaiveLanternFishesTests : LanternfishesTests<Lanternfishes.Naive>
    {
        protected override Lanternfishes.Naive BuildLanternfishes(int[] internalTimers) => new(internalTimers);
    }

    public class OptimalLanternFishesTests : LanternfishesTests<Lanternfishes.Optimal>
    {
        protected override Lanternfishes.Optimal BuildLanternfishes(int[] internalTimers) => new(internalTimers);
    }

    public abstract class LanternfishesTests<TLanternfishes> where TLanternfishes : ILanternfishes
    {
        [Fact]
        public void NewDay_When1InternalTimer0_IncrementsCount()
        {
            var lanternFishes = BuildLanternfishes(0);

            lanternFishes.SimulateOneDay();

            lanternFishes.Count.Should().Be(2, "0 means one days is left to pass until a new Lanternfish is spawned.");
        }

        [Fact]
        public void NewDay_When1InternalTimer1_DoesNotIncrementCount()
        {
            var lanternFishes = BuildLanternfishes(1);

            lanternFishes.SimulateOneDay();

            lanternFishes.Count.Should().Be(1, "1 signifies that there are 2 days yet to pass for a new Lanternfish to be spawned.");
        }

        [Fact]
        public void NewDay_GivenDaysPassedForTheNewLanternfishToSpawnAnother_When1InternalTimer0_xxxx()
        {
            // Arrange
            var lanternFishes = BuildLanternfishes(0);
            // +1, because one day is needed for the parent to spawn a new one.
            for (int i = 0; i < Lanternfishes.DaysUntilChildLanternfishSpawnAnother + 1; i++)
            {
                lanternFishes.SimulateOneDay();
            }

            // Act
            lanternFishes.SimulateOneDay();

            // Assert
            lanternFishes.Count.Should().Be(4, "On the first day parent spawn a new child." +
                                               $"After {Lanternfishes.DaysUntilFirstLanternfishSpawnAnother} days - a parent is ready to spawn another child." +
                                               $"After the {Lanternfishes.DaysUntilChildLanternfishSpawnAnother} days from being born ({Lanternfishes.DaysUntilChildLanternfishSpawnAnother + 1} in total) - the child spawns another fish." +
                                               "4 fishes total");
        }

        protected abstract TLanternfishes BuildLanternfishes(params int[] internalTimers);
    }
}
