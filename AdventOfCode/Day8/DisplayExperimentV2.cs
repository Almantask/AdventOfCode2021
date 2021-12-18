using AdventOfCode.Common;

namespace AdventOfCode.Day8
{
    /// <summary>
    /// <para>
    /// Digit eight is always needed as an argument, because it will be used as a map for all the other digits.
    /// In other words- it is the complete 7-digit segments array.
    /// </para>
    /// <para>
    /// Finding a digit means looking for its index inside 10-signals.
    /// </para>
    /// <para>
    /// Finding a segments means looking for its equivalent inside digit eight segments.
    /// </para>
    /// </summary>
    public class DisplayExperimentV2 : DisplayExperiment
    {
        private DisplayExperimentV2(string[] tenSignalPatterns, string[] fourDigitsOutput) : base(tenSignalPatterns, fourDigitsOutput)
        {
        }

        #region Step 1: Numbers with unique count of segments

        public int FindDigitOne() => TenSignalPatterns.IndexOf(e => e.Length == 2);

        public int FindDigitFour() => TenSignalPatterns.IndexOf(e => e.Length == 4);

        public int FindDigitSeven() => TenSignalPatterns.IndexOf(e => e.Length == 3);

        public int FindDigitEight() => TenSignalPatterns.IndexOf(e => e.Length == 7);

        // Known:
        // **1**, **4**, **7**, **8**

        #endregion

        #region Step 2: Digit one unique overlaps

        /// <summary>
        /// Digit two overlaps with digit one at exactly one segment - c.
        /// </summary>
        public (int indexOfDigitTwo, char segmentC) FindDigitTwoAndSegmentC(char[] digitOne)
        {
            return (1, 'c');
        }

        /// <summary>
        /// Digit five overlaps with digit one at exactly one segment - f.
        /// </summary>
        public (int indexOfDigitFive, char segmentF) FindDigitFiveAndSegmentF(char[] digitOne)
        {
            return (1, 'f');
        }

        /// <summary>
        /// Digit seven compared to digit one has 1 extra segment - a.
        /// </summary>
        public char FindSegmentA(char[] digitSeven, char[] digitOne, char[] digitEight)
        {
            var segmentA = digitSeven.Except(digitOne).First();
            return segmentA;
        }

        // Known:
        // **a**, **c**, **f**
        // 1, **2**, 4, **5**, 7, 8

        #endregion

        #region Step 3: Wrapping up known numbers

        /// <summary>
        /// Digit four overlaps digit one completely.
        /// Digit four overlaps with digit three at a 1 extra segment - d.
        /// Knowing segment d - we're left with the last segment on digit four - b.
        /// </summary>
        /// <returns></returns>
        public (int digitThree, char segementD, char segmentB) FindDigitThreeAndSegmentDAndSegmentB(char[] digitOne, char[] digitFour)
        {
            return (0, 'd', 'b');
        }

        // Known:
        // a, *b*, c, *d*, f
        // 1, 2, *3*, 4, 5, 7, 8

        #endregion

        #region Step 4: Digit five is almost like digit six

        // 6 overlaps in all segments but 1 with digit five- e.
        public (int digitSix, char segmentE) FindDigitSixAndSegmentE(char[] digitFive)
        {
            return (6, 'e');
        }

        // Known:
        // a, b, c, d, **e**, f
        // 1, 2, 3, 4, 5, **6**, 7, 8

        #endregion

        #region Step 5: The last remaining segment

        // The last missing segment is g. With it, we can deduce the remaining numbers.
        public char FindSegmentG(char[] knownSegments, char[] unknownSegments)
        {
            return unknownSegments.Except(knownSegments).First();
        }

        public int FindDigitZero(Dictionary<char, char> segmentsMap)
        {
            return 0;
        }

        public int FindDigitNine(Dictionary<char, char> segmentsMap)
        {
            return 0;
        }
        // Known:
        // a, b, c, d, e, f, **g**
        // **0**, 1, 2, 3, 4, 5, 6, 7, 8, **9**

        #endregion

        public static DisplayExperimentV2 Parse(string experimentText)
        {
            var (tenSignalPatterns, fourDigitsOutput) = ParseParts(experimentText);
            return new DisplayExperimentV2(tenSignalPatterns, fourDigitsOutput);
        }
    }
}
