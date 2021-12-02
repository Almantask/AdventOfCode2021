using AdventOfCode.Day1;
using AdventOfCode.Day2;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AdventOfCode.Tests.Day2
{
    public class SumbarineControlsTests
    {
        private readonly SubmarineControls _controls;

        public SumbarineControlsTests()
        {
            _controls = new SubmarineControls();
        }

        [Fact]
        public void New_IsAt0DepthAnd0Horizon()
        {
            using (new AssertionScope())
            {
                _controls.Depth.Should().Be(0);
                _controls.Horizon.Should().Be(0);
            }
        }

        [Fact]
        public void Forward_IncreasesHorizontal()
        {
            _controls.Forward(1);

            _controls.Horizon.Should().Be(1);
        }

        [Fact]
        public void Down_IncreasesDepth()
        {
            _controls.Down(1);

            _controls.Depth.Should().Be(1);
        }

        [Fact]
        public void Up_DecreasesDepth()
        {
            _controls.Up(1);

            _controls.Depth.Should().Be(-1);
        }

        [Fact]
        public void Move_Forward_Up_And_Down_MovesOnHorizon()
        {
            _controls.Forward(1);
            _controls.Forward(1);
            _controls.Up(1);
            _controls.Down(1);

            using (new AssertionScope())
            {
                _controls.Depth.Should().Be(0);
                _controls.Horizon.Should().Be(2);
            }
        }
    }
}
