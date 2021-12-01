using AdventOfCode.Exec;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Main_DoesNotThrow()
        {
            var main = () => Program.Main(null);

            main.Should().NotThrow();
        }
    }
}
