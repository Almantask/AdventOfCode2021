namespace AdventOfCode.Common
{
    public static class StringExtensions
    {
        public static string[] SplitByEndOfLine(this string text)
            => text.Split($"{Environment.NewLine}");

        public static long[] ToNumbersSplitByEndOfLine(this string text)
        {
            var numbers = text
                .Split(Environment.NewLine)
                .Select(long.Parse)
                .ToArray();

            return numbers;
        }
    }
}
