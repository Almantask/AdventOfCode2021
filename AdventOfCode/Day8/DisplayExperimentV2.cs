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

        // The order of calling the methods does not matter, because they expose what is required in their arguments.
        // However, in order to get what is required - call methods in the order of their declaration.

        #region Step 1: Numbers with unique count of segments

        public int FindDigitOne() => SignalPatterns.IndexOf(e => e.Length == 2);

        public int FindDigitFour() => SignalPatterns.IndexOf(e => e.Length == 4);

        public int FindDigitSeven() => SignalPatterns.IndexOf(e => e.Length == 3);

        public int FindDigitEight() => SignalPatterns.IndexOf(e => e.Length == 7);

        // Known:
        // **1**, **4**, **7**, **8**

        #endregion

        #region Step 2: Digit one unique overlaps

        /// <summary>
        /// Digit two overlaps with digit one at exactly 1 segment - c.
        /// Digit two overlaps with digit four at 2 segments.
        /// </summary>
        public (int indexOfDigitTwo, char segmentC) FindDigitTwoAndSegmentC(char[] digitOne, char[] digitFour)
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
                    return (i, overlap.First());
                }
            }

            throw new InvalidOperationException("Either not a digit one passed or an invalid experiment");
        }

        /// <summary>
        /// Digit five overlaps with digit one at exactly 1 segment - f.
        /// Digit five overlaps with digit four at 3 segments.
        /// </summary>
        public (int indexOfDigitFive, char segmentF) FindDigitFiveAndSegmentF(char[] digitOne, char[] digitFour)
        {
            for (int i = 0; i < SignalsCount; i++)
            {
                var signal = GetSignalPattern(i);
                var overlap = digitOne.Intersect(signal);

                var isDigitTwoOrDigitFive = overlap.Count() == 1;
                if (!isDigitTwoOrDigitFive) continue;

                // Digit five overlaps with digit four at 3 segments.
                var isDigitTwo = digitFour.Intersect(signal).Count() == 3;
                if (isDigitTwo)
                {
                    return (i, overlap.First());
                }
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
        public (int digitThree, char segementD, char segmentB) FindDigitThreeAndSegmentDAndSegmentB(char[] digitOne, char[] digitFour)
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

                return (indexOfDigitThree, segmentD, segmentB);
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
        /// </summary>
        public (int digitSix, char segmentE) FindDigitSixAndSegmentE(char[] digitFive)
        {
            var digitSixSegmentsCount = DisplayDigit.Create(6).Segments.Length;
            for (int i = 0; i < SignalsCount; i++)
            {
                var signal = GetSignalPattern(i);
                var signalSegmentsCount = signal.Length;
                if (signalSegmentsCount != digitSixSegmentsCount) continue;

                var intersection = signal.Intersect(digitFive).ToArray();
                var intersectionSegmentsCount = intersection.Count();
                if (signalSegmentsCount - intersectionSegmentsCount != 1) continue;

                var indexOfDigitSix = i;
                var segmentE = signal.Except(intersection).First();

                return (indexOfDigitSix, segmentE);
            }

            throw new InvalidOperationException("Either invalid digits passed or an invalid experiment");
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
            var properDigitZero = DisplayDigit.Create(0);
            char[] digitZeroAsSignal = MapToSignalSegments(segmentsMap, properDigitZero);
            return FindDigitAsSignal(digitZeroAsSignal);
        }

        public int FindDigitNine(Dictionary<char, char> segmentsMap)
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

        private int FindDigitAsSignal(char[] digitAsSignal)
        {
            for (int i = 0; i < SignalsCount; i++)
            {
                var signal = GetSignalPattern(i);
                if (signal.IsEquivalentTo(digitAsSignal))
                {
                    return i;
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
    }
}
