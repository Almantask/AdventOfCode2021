namespace AdventOfCode.Common
{
    public static class JaggedArrayExtensions
    {
        public static T[] To1D<T>(this T[,] source)
        {
            var oneDimensional = new T[source.GetLength(0) * source.GetLength(1)];
            var index = 0;
            foreach (var element in source)
            {
                oneDimensional[index] = element;
                index++;
            }

            return oneDimensional;
        }

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

        public static void ShiftBy1ToLeft<T>(this T[] elements)
        {
            var first = elements.First();
            for (var index = 1; index < elements.Length; index++)
            {
                var current = elements[index];
                elements[index - 1] = current;
            }

            elements[^1] = first;
        }
    }
}
