using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Day6
{
    public class LanternfishTests
    {
        [Fact]
        public void NewDay_When1InternalTimer0_IncrementsCount()
        {
            var lanternFishes = new Lanternfishes(0);

            lanternFishes.SimulateOneDay();

            lanternFishes.Count.Should().Be(2, "0 means one days is left to pass until a new Lanternfish is spawned.");
        }

        [Fact]
        public void NewDay_When1InternalTimer1_DoesNotIncrementCount()
        {
            var lanternFishes = new Lanternfishes(1);

            lanternFishes.SimulateOneDay();

            lanternFishes.Count.Should().Be(1, "1 signifies that there are 2 days yet to pass for a new Lanternfish to be spawned.");
        }

        [Fact]
        public void NewDay_GivenDaysPassedForTheNewLanternfishToSpawnAnother_When1InternalTimer0_xxxx()
        {
            // Arrange
            var lanternFishes = new Lanternfishes(0);
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
    }
}
