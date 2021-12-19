using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.Day8
{
    /// <summary>
    /// <para>
    /// Digit eight is always needed as an argument, because it will be used as a map for all the other digits.
    /// In other words- it is the complete 7-digit segments array.
    /// </para>
    /// <para>
    /// Finding a digit means looking for its segments inside 10-signals.
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

        // The order of calling the methods does not matter, because they expose what is required in their arguments.
        // However, in order to get what is required - call methods in the order of their declaration.

        #region Step 1: Numbers with unique count of segments

        public char[] FindDigitOne() => GetDigitSegmentsMatchingCriteria(e => e.Length == 2);

        public char[] FindDigitFour() => GetDigitSegmentsMatchingCriteria(e => e.Length == 4);

        public char[] FindDigitSeven() => GetDigitSegmentsMatchingCriteria(e => e.Length == 3);

        public char[] FindDigitEight() => GetDigitSegmentsMatchingCriteria(e => e.Length == 7);

        // Known:
        // **1**, **4**, **7**, **8**

        #endregion

        #region Step 2: Digit one unique overlaps

        /// <summary>
        /// Digit two overlaps with digit one at exactly 1 segment - c.
        /// Digit two overlaps with digit four at 2 segments.
        /// </summary>
        public (char[] digitTwoSegments, char segmentC) FindDigitTwoAndSegmentC(char[] digitOne, char[] digitFour)
        {
            for (int i = 0; i < SignalsCount; i++)
            {
                var signal = GetSignalPattern(i);
                var overlap = digitOne.Intersect(signal);

                var isDigitTwoOrDigitFive = overlap.Count() == 1;
                if (!isDigitTwoOrDigitFive) continue;

                // Digit two overlaps with digit four at 2 segments.
                var isDigitTwo = digitFour.Intersect(signal).Count() == 2;
                if (isDigitTwo)
                {
                    return (GetSignalPattern(i), overlap.First());
                }
            }

            throw new InvalidOperationException("Either not a digit one passed or an invalid experiment");
        }

        /// <summary>
        /// Digit five overlaps with digit one at exactly 1 segment - f.
        /// Digit five overlaps with digit four at 3 segments.
        /// Digit 5 has 5 segments.
        /// </summary>
        public (char[] digitFiveSegments, char segmentF) FindDigitFiveAndSegmentF(char[] digitOne, char[] digitFour)
        {
            for (int i = 0; i < SignalsCount; i++)
            {
                var signal = GetSignalPattern(i);
                var overlap = digitOne.Intersect(signal);

                var isDigitFiveOrDigitSixOrDigitTwo = overlap.Count() == 1;
                if (!isDigitFiveOrDigitSixOrDigitTwo) continue;

                // Digit five overlaps with digit four at 3 segments.
                var isDigitFiveOrDigitSix = digitFour.Intersect(signal).Count() == 3;
                if (!isDigitFiveOrDigitSix) continue;

                // Digit 5 has 5 segments
                var isDigitFive = signal.Length == 5;
                if (isDigitFive) return (GetSignalPattern(i), overlap.First());
            }

            throw new InvalidOperationException("Either not a digit one passed or an invalid experiment");
        }

        /// <summary>
        /// Digit seven compared to digit one has 1 extra segment - a.
        /// </summary>
        public char FindSegmentA(char[] digitSeven, char[] digitOne)
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
        public (char[] digitThreeSegments, char segementD, char segmentB) FindDigitThreeAndSegmentDAndSegmentB(char[] digitOne, char[] digitFour)
        {
            var digitFourOverlapWithDigitOne = digitOne.Intersect(digitFour).ToArray();
            for (int i = 0; i < SignalsCount; i++)
            {
                var signal = GetSignalPattern(i);
                var intersection = digitFour.Intersect(signal).ToArray();

                var isDigitThree = intersection.Count() == 3;
                isDigitThree = isDigitThree && digitFourOverlapWithDigitOne.All(e => intersection.Contains(e));
                if (!isDigitThree) continue;

                var indexOfDigitThree = i;

                var segmentD = intersection
                    .Except(digitFourOverlapWithDigitOne)
                    .First();

                var segmentB = digitFour
                    .Except(digitOne)
                    .Except(new[] { segmentD })
                    .First();

                return (GetSignalPattern(indexOfDigitThree), segmentD, segmentB);
            }

            throw new InvalidOperationException("Either invalid digits passed or an invalid experiment");
        }

        // Known:
        // a, *b*, c, *d*, f
        // 1, 2, *3*, 4, 5, 7, 8

        #endregion

        #region Step 4: Digit five is almost like digit six

        /// <summary>
        /// Digit six overlaps in all segments but 1 with digit five - e.
        /// It also must contain C - because otherwise it can be confused with a digit nine.
        /// </summary>
        public (char[] digitSixSegments, char segmentE) FindDigitSixAndSegmentE(char[] digitFive, char segmentC)
        {
            var digitSixSegmentsCount = DisplayDigit.Create(6).Segments.Length;
            for (int i = 0; i < SignalsCount; i++)
            {
                var signal = GetSignalPattern(i);
                var signalSegmentsCount = signal.Length;
                if (signalSegmentsCount != digitSixSegmentsCount) continue;

                var segmentNotInFive = signal.Except(digitFive).ToArray();
                if (segmentNotInFive.Count() != 1) continue;

                var segmentE = segmentNotInFive.First();
                // Is the difference is C - that means it is a nine, however we need a six.
                var isSix = segmentE != segmentC;
                if (!isSix) continue;

                return (GetSignalPattern(i), segmentE);
            }

            throw new InvalidOperationException("Either invalid digits passed or an invalid experiment");
        }

        // Known:
        // a, b, c, d, **e**, f
        // 1, 2, 3, 4, 5, **6**, 7, 8

        #endregion

        #region Step 5: The last remaining segment

        /// <summary>
        /// The last missing segment is g. With it, we can deduce the remaining numbers.
        /// </summary>
        public char FindSegmentG(char[] knownSegments)
        {
            var allSegments = DisplayDigit.Create(8).Segments;
            return allSegments.Except(knownSegments).First();
        }

        public char[] FindDigitZero(Dictionary<char, char> segmentsMap)
        {
            var properDigitZero = DisplayDigit.Create(0);
            char[] digitZeroAsSignal = MapToSignalSegments(segmentsMap, properDigitZero);
            return FindDigitAsSignal(digitZeroAsSignal);
        }

        public char[] FindDigitNine(Dictionary<char, char> segmentsMap)
        {
            var properDigitNine = DisplayDigit.Create(9);
            char[] digitZeroAsSignal = MapToSignalSegments(segmentsMap, properDigitNine);
            return FindDigitAsSignal(digitZeroAsSignal);
        }

        private char[] MapToSignalSegments(Dictionary<char, char> segmentsMap, DisplayDigit properDigit)
        {
            var sb = new StringBuilder();
            foreach (var segment in properDigit.Segments)
            {
                sb.Append(segmentsMap[segment]);
            }

            var digitZeroAsSignal = sb.ToString().ToCharArray();
            return digitZeroAsSignal;
        }

        private char[] FindDigitAsSignal(char[] digitAsSignal)
        {
            for (int i = 0; i < SignalsCount; i++)
            {
                var signal = GetSignalPattern(i);
                if (signal.IsEquivalentTo(digitAsSignal))
                {
                    return GetSignalPattern(i);
                }
            }

            throw new InvalidOperationException("Passed invalid segments map or invalid experiment");
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

        private char[] GetDigitSegmentsMatchingCriteria(Predicate<char[]> criteria)
        {
            var index = SignalPatterns.IndexOf(criteria);
            return GetSignalPattern(index);
        }
    }
}
