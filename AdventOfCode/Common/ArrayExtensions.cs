namespace AdventOfCode.Common
{
    public static class JaggedArrayExtensions
    {
        public static T[,] To2D<T>(this T[][] source)
        {
            try
            {
                int firstDimension = source.Length;
                int secondDimension = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[firstDimension, secondDimension];
                for (var i = 0; i < firstDimension; ++i)
                    for (var j = 0; j < secondDimension; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }
    }
}
