namespace AdventOfCode.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static double Median(this IEnumerable<int> numbers)
        {
            if (numbers == null || !numbers.Any()) throw new InvalidOperationException("At least one number is required");

            var count = numbers.Count();
            if (count == 1) return numbers.First();

            var ordered = numbers.OrderBy(i => i).ToArray();
            var isEvenCount = count % 2 == 0;
            var middle = ordered[count / 2];
            var beforeMiddle = ordered[count / 2] - 1;
            var median = isEvenCount ? (middle + beforeMiddle) / 2.0 : middle;

            return median;
        }
    }
}
