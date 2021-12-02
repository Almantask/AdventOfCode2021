using AdventOfCode.Exec;

namespace AdventOfCode.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Main_DoesNotThrow()
        {
            var main = () => Program.Main(Array.Empty<string>());

            main.Should().NotThrow();
        }
    }
}
