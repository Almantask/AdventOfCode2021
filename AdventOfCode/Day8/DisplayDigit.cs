namespace AdventOfCode.Day8
{
    public class DisplayDigit
    {
        private static readonly DisplayDigit[] _displayDigits =
        {
            new(0, new []{'a', 'b', 'c', 'e', 'f', 'g'}),
            new(1, new []{'c', 'f'}),
            new(2, new []{'a', 'c', 'd', 'e', 'g'}),
            new(3, new []{'a', 'c', 'd', 'f', 'g'}),
            new(4, new []{'b', 'c', 'd', 'f'}),
            new(5, new []{'a', 'b', 'd', 'f', 'g'}),
            new(6, new []{'a', 'b', 'd', 'e', 'f', 'g'}),
            new(7, new []{'a', 'c', 'f'}),
            new(8, new []{'a', 'b', 'c', 'd', 'e', 'f', 'g'}),
            new(9, new []{'a', 'b', 'c', 'd', 'f', 'g'})
        };

        public int Digit { get; }
        public char[] Segments { get; }

        private DisplayDigit(int digit, char[] segments)
        {
            Digit = digit;
            Segments = segments;
        }

        public static DisplayDigit Create(int digit)
        {
            if (digit >= _displayDigits.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Only single digit (0-9) are available.");
            }

            return _displayDigits[digit];
        }
    }
}
