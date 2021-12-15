namespace AdventOfCode.Day8
{
    public class DisplayDigit
    {
        private static readonly DisplayDigit[] _displayDigits =
        {
            new(0, new []{'a', 'b', 'c', 'e', 'f', 'g'}, false),
            new(1, new []{'c', 'f'}, true),
            new(2, new []{'a', 'c', 'd', 'e', 'g'}, false),
            new(3, new []{'a', 'c', 'd', 'f', 'g'}, false),
            new(4, new []{'b', 'c', 'd', 'f'}, true),
            new(5, new []{'a', 'b', 'd', 'f', 'g'}, false),
            new(6, new []{'a', 'b', 'd', 'e', 'f', 'g'}, false),
            new(7, new []{'a', 'c', 'f'}, true),
            new(8, new []{'a', 'b', 'c', 'd', 'e', 'f', 'g'}, true),
            new(9, new []{'a', 'b', 'c', 'd', 'f', 'g'}, false)
        };

        public int Digit { get; }
        public char[] Segments { get; }
        private readonly bool _isUniqueSegmentsCount;

        private DisplayDigit(int digit, char[] segments, bool isUniqueSegmentsCount)
        {
            Digit = digit;
            Segments = segments;
            _isUniqueSegmentsCount = isUniqueSegmentsCount;
        }

        public static DisplayDigit Create(int digit)
        {
            if (digit >= _displayDigits.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Only single digit (0-9) are available.");
            }

            return _displayDigits[digit];
        }

        public bool IsGuaranteedToBeMadeFromRandomSegments(char[] segments)
        {
            return _isUniqueSegmentsCount &&
                   segments.Length == Segments.Length;
        }
    }
}
