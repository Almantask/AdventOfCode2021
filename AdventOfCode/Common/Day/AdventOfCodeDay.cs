namespace AdventOfCode.Common.Day
{
    public interface IAdventOfCodeDay
    {
        void Solve();
    }

    public abstract class AdventOfCodeDay<TPart1, TPart2> : IAdventOfCodeDay
        where TPart1 : class, IPartSolution, new()
        where TPart2 : class, IPartSolution, new()
    {
        protected abstract int Day { get; }

        public void Solve()
        {
            var input = File.ReadAllText($"Day{Day}/Input.txt");

            var part1 = new TPart1();
            var part2 = new TPart2();

            Console.WriteLine($"Day{Day}, part1 answer: " + part1.Solve(input));
            Console.WriteLine($"Day{Day}, Part2 answer: " + part2.Solve(input));
        }
    }
}
