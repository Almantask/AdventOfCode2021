using AdventOfCode.Day2;
using Moq;

namespace AdventOfCode.Tests.Day2
{
    public class SubmarinePilotTests
    {
        private readonly SubmarinePilot _pilot;

        private readonly Mock<ISubmarineControls> _controls;

        public SubmarinePilotTests()
        {
            _controls = new Mock<ISubmarineControls>();
            _pilot = new SubmarinePilot(_controls.Object);
        }

        [Fact]
        public void Move_WhenForward_MovesForward()
        {
            const string instructionToMoveForwardBy1 = "forward 1";

            _pilot.Move(instructionToMoveForwardBy1);

            _controls.Verify(c => c.Forward(1));
        }

        [Fact]
        public void Move_WhenDown_MovesDown()
        {
            const string instructionToMoveDownBy1 = "down 1";

            _pilot.Move(instructionToMoveDownBy1);

            _controls.Verify(c => c.Down(1));
        }

        [Fact]
        public void Move_WhenUp_MovesUp()
        {
            const string instructionToMoveUpBy1 = "up 1";

            _pilot.Move(instructionToMoveUpBy1);

            _controls.Verify(c => c.Up(1));
        }
    }
}
