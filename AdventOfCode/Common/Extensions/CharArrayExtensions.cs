namespace AdventOfCode.Common.Extensions
{
    public static class CharArrayExtensions
    {
        public static long ToLong(this char[] binaryNumber)
        {
            double converted = 0;
            double rank = binaryNumber.Length;
            foreach (var character in binaryNumber)
            {
                // First rank is 0 in case of 1 digit (2^0 = 1)
                rank--;
                double toBeSummed = character switch
                {
                    '0' => 0,
                    '1' => Math.Pow(2, rank),
                    _ => throw new ArgumentException("Not a binary number", nameof(binaryNumber))
                };

                converted += toBeSummed;
            }

            return (long)converted;
        }

        public static char[] FlipBits(this char[] binaryNumber)
        {
            char[] flippedBits = new char[binaryNumber.Length];
            for (var index = 0; index < binaryNumber.Length; index++)
            {
                var character = binaryNumber[index];
                char bit = character switch
                {
                    '0' => '1',
                    '1' => '0',
                    _ => throw new ArgumentException("Not a binary number", nameof(binaryNumber))
                };

                flippedBits[index] = bit;
            }

            return flippedBits;
        }
    }
}
