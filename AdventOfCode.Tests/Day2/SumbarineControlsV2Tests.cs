using AdventOfCode.Day1;
using AdventOfCode.Day2;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AdventOfCode.Tests.Day2
{
    public class SumbarineControlsV2Tests
    {
        private readonly SubmarineControlsV2 _controlsV2;

        public SumbarineControlsV2Tests()
        {
            _controlsV2 = new SubmarineControlsV2();
        }

        [Fact]
        public void New_IsAt0DepthAnd0Horizon()
        {
            using (new AssertionScope())
            {
                _controlsV2.Depth.Should().Be(0);
                _controlsV2.Horizon.Should().Be(0);
            }
        }

        [Fact]
        public void Forward_Increases_Horizontal_And_DepthMultipliedByAim()
        {
            // Arrange
            const int aim = 2;
            _controlsV2.Down(aim);

            // Act
            _controlsV2.Forward(3);

            // Assert
            _controlsV2.Horizon.Should().Be(3);
            _controlsV2.Depth.Should().Be(6);
        }

        [Fact]
        public void Down_IncreasesAim()
        {
            _controlsV2.Down(1);

            _controlsV2.Aim.Should().Be(1);
        }

        [Fact]
        public void Up_DecreasesAim()
        {
            _controlsV2.Up(1);

            _controlsV2.Aim.Should().Be(-1);
        }

        [Fact]
        public void Move_Forward_Up_And_Down_MovesOnHorizon()
        {
            _controlsV2.Forward(1);
            _controlsV2.Forward(1);
            _controlsV2.Up(1);
            _controlsV2.Down(1);

            using (new AssertionScope())
            {
                _controlsV2.Depth.Should().Be(0);
                _controlsV2.Horizon.Should().Be(2);
            }
        }
    }
}
