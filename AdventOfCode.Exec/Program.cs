using AdventOfCode.Common;
using AdventOfCode.Day1;

namespace AdventOfCode.Exec
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve<Day1Solution>();
        }

        private static void Solve<TAdventOfCodeDay>() where TAdventOfCodeDay : IDaySolution, new()
        {
            new TAdventOfCodeDay().Solve();
        }
    }
}
