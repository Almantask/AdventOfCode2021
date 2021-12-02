namespace AdventOfCode.Day2
{
    public class SubmarinePilot
    {
        public int Depth => _controls.Depth;
        public int Horizon => _controls.Horizon;

        private readonly Dictionary<SubmarineMove.Direction, Action<int>> _movements;

        private readonly SubmarineControls _controls;

        public SubmarinePilot(SubmarineControls controls)
        {
            _controls = controls;
            _movements = new()
            {
                { SubmarineMove.Direction.Down, (amount) => _controls.Down(amount) },
                { SubmarineMove.Direction.Up, (amount) => _controls.Up(amount) },
                { SubmarineMove.Direction.Forward, (amount) => _controls.Forward(amount) }
            };
        }

        public void Move(string instructionLiteral)
        {
            var instruction = SubmarineMove.Instruction.Parse(instructionLiteral);
            _movements[instruction.Direction](instruction.Amount);
        }
    }
}
