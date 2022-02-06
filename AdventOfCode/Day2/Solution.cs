using AdventOfCode.Common;
using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day2
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 2;

        public class Part<TControls> : IPartSolution
            where TControls : ISubmarineControls, new()
        {
            public long Solve(string input)
            {
                var pilot = new SubmarinePilot(new TControls());
                var instructions = input.SplitByEndOfLine();
                foreach (var instruction in instructions)
                {
                    pilot.Move(instruction);
                }

                var result = pilot.Depth * pilot.Horizon;

                return result;
            }
        }
    }

    public class Part1 : Solution.Part<SubmarineControlsV1> { }

    public class Part2 : Solution.Part<SubmarineControlsV2> { }
}
