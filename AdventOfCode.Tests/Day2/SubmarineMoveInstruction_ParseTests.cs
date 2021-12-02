using AdventOfCode.Day2;

namespace AdventOfCode.Tests.Day2
{
    public class SubmarineMoveInstruction_Parse_Tests
    {
        // Assume all instructions are in correct format
        [Theory]
        [InlineData("forward 2", SubmarineMove.Direction.Forward, 2)]
        [InlineData("down 1", SubmarineMove.Direction.Down, 1)]
        [InlineData("up 5", SubmarineMove.Direction.Up, 5)]
        public void Parse_ReturnsMoveInstruction(string moveInstruction, SubmarineMove.Direction expectedDirection, int expectedAmount)
        {
            var expectedInstruction = new SubmarineMove.Instruction(expectedDirection, expectedAmount);

            var instruction = SubmarineMove.Instruction.Parse(moveInstruction);

            expectedInstruction.Should().BeEquivalentTo(instruction);
        }
    }
}
