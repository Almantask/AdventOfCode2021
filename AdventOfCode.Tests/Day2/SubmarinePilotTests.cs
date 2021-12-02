using AdventOfCode.Day2;
using Moq;

namespace AdventOfCode.Tests.Day2
{
    public class SubmarinePilotTests
    {
        public readonly SubmarinePilot _pilot;

        private readonly Mock<ISubmarineControls> _controls;

        public SubmarinePilotTests()
        {
            _controls = new Mock<ISubmarineControls>();
            _pilot = new SubmarinePilot(_controls.Object);
        }

        [Fact]
        public void Move_WhenForward_MovesForward()
        {
            _pilot.Move("forward 1");

            _controls.Verify(c => c.Forward(1));
        }

        [Fact]
        public void Move_WhenDown_MovesDown()
        {
            _pilot.Move("down 1");

            _controls.Verify(c => c.Down(1));
        }

        [Fact]
        public void Move_WhenUp_MovesUp()
        {
            _pilot.Move("up 1");

            _controls.Verify(c => c.Up(1));
        }
    }
}
