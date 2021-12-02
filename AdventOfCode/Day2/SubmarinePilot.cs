namespace AdventOfCode.Day2
{
    public class SubmarinePilot
    {
        public int Depth => _controlsV1.Depth;
        public int Horizon => _controlsV1.Horizon;

        private readonly Dictionary<SubmarineMove.Direction, Action<int>> _movements;

        private readonly ISubmarineControls _controlsV1;

        public SubmarinePilot(ISubmarineControls controlsV1)
        {
            _controlsV1 = controlsV1;
            _movements = new()
            {
                { SubmarineMove.Direction.Down, (amount) => _controlsV1.Down(amount) },
                { SubmarineMove.Direction.Up, (amount) => _controlsV1.Up(amount) },
                { SubmarineMove.Direction.Forward, (amount) => _controlsV1.Forward(amount) }
            };
        }

        public void Move(string instructionLiteral)
        {
            var instruction = SubmarineMove.Instruction.Parse(instructionLiteral);
            _movements[instruction.Direction](instruction.Amount);
        }
    }
}
