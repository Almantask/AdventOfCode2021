using AdventOfCode.Common;

namespace AdventOfCode.Exec
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Solve<Day1.Solution>();
            Solve<Day2.Solution>();
            Solve<Day3.Solution>();
            Solve<Day4.Solution>();
            Solve<Day5.Solution>();
            Solve<Day6.Solution>();
            Solve<Day7.Solution>();
            Solve<Day8.Solution>();
        }

        private static void Solve<TAdventOfCodeDay>() where TAdventOfCodeDay : IDaySolution, new()
        {
            new TAdventOfCodeDay().Solve();
        }
    }
}
