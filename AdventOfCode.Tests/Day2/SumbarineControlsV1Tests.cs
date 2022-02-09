using AdventOfCode.Day2;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day2
{
    public class SubmarineControlsV1Tests
    {
        private readonly SubmarineControlsV1 _controlsV1;

        public SubmarineControlsV1Tests()
        {
            _controlsV1 = new SubmarineControlsV1();
        }

        [Fact]
        public void New_IsAt0DepthAnd0Horizon()
        {
            var newControl = new SubmarineControlsV1();

            using (new AssertionScope())
            {
                newControl.Depth.Should().Be(0);
                newControl.Horizon.Should().Be(0);
            }
        }

        [Fact]
        public void Forward_IncreasesHorizontal()
        {
            _controlsV1.Forward(1);

            _controlsV1.Horizon.Should().Be(1);
        }

        [Fact]
        public void Down_IncreasesDepth()
        {
            _controlsV1.Down(1);

            _controlsV1.Depth.Should().Be(1);
        }

        [Fact]
        public void Up_DecreasesDepth()
        {
            _controlsV1.Up(1);

            _controlsV1.Depth.Should().Be(-1);
        }

        [Fact]
        public void Move_Forward_Up_And_Down_MovesOnHorizon()
        {
            _controlsV1.Forward(1);
            _controlsV1.Forward(1);
            _controlsV1.Up(1);
            _controlsV1.Down(1);

            using (new AssertionScope())
            {
                _controlsV1.Depth.Should().Be(0);
                _controlsV1.Horizon.Should().Be(2);
            }
        }
    }
}
