namespace AdventOfCode.Common.Extensions
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
                {
                    for (var j = 0; j < secondDimension; ++j)
                    {
                        result[i, j] = source[i][j];
                    }
                }

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

        /// <summary>
        /// Find index by <see cref="criteria"/> in <see cref="elements"/> array.
        /// </summary>
        /// <returns>-1 if not found, else index of the first element found by the criteria.</returns>
        public static int IndexOf<T>(this T[] elements, Predicate<T> criteria)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (criteria(elements[i])) return i;
            }

            const int notFound = -1;
            return notFound;
        }

        public static bool IsEquivalentTo<T>(this IEnumerable<T> a, IEnumerable<T> b)
        {
            if (a == null || b == null) return false;

            var aCount = a.Count();
            return (aCount == b.Count() && a.Intersect(b).Count() == aCount);
        }
    }
}
