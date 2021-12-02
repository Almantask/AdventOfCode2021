using AdventOfCode.Common;

namespace AdventOfCode.Day2
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 2;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            var pilot = new SubmarinePilot(new SubmarineControlsV1());
            var instructions = input.SplitByEndOfLine();
            foreach (var instruction in instructions)
            {
                pilot.Move(instruction);
            }

            var result = pilot.Depth * pilot.Horizon;

            return result;
        }
    }

    public class Part2 : IPartSolution
    {
        public long Solve(string input)
        {
            return 0;
        }
    }
}
