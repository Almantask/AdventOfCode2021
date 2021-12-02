using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day2;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AdventOfCode.Tests.Day2
{
    public class SubmarinePilotTests
    {
        public SubmarinePilot _pilot;

        public SubmarinePilotTests()
        {
            var controls = new SubmarineControls();
            _pilot = new SubmarinePilot(controls);
        }

        [Theory]
        [InlineData("forward 1", 1, 0)]
        [InlineData("up 1", 0, -1)]
        [InlineData("down 1", 0, 1)]
        public void Move_MovesExpectedPart(string instruction, int expectedHorizon, int expectedDepth)
        {
            _pilot.Move(instruction);

            using (new AssertionScope())
            {
                _pilot.Depth.Should().Be(expectedDepth);
                _pilot.Horizon.Should().Be(expectedHorizon);
            }
        }
    }
}
