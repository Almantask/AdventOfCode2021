namespace AdventOfCode.Day2
{
    public static class SubmarineMove
    {
        public enum Direction
        {
            Forward,
            Down,
            Up
        }

        public class Instruction
        {
            private static readonly Dictionary<string, Direction> _directions = new()
            {
                { "forward", Direction.Forward },
                { "down", Direction.Down },
                { "up", Direction.Up }
            };

            public Direction Direction { get; }
            public int Amount { get; }

            public Instruction(Direction direction, int amount)
            {
                Direction = direction;
                Amount = amount;
            }

            public static Instruction Parse(string moveInstruction)
            {
                var split = moveInstruction.Split(' ');
                var direction = _directions[split[0]];
                var amount = int.Parse(split[1]);

                return new Instruction(direction, amount);
            }
        }
    }

}
