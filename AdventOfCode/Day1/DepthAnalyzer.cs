namespace AdventOfCode.Day1
{
    public static class DepthAnalyzer
    {
        public static long CountIncreases(long[] depthMeasurements)
        {
            var increases = 0;
            for (var i = 1; i < depthMeasurements.Length; i++)
            {
                var previous = depthMeasurements[i - 1];
                var current = depthMeasurements[i];
                if (current > previous)
                {
                    increases++;
                }
            }

            return increases;
        }

        public static long Count3WindowIncreases(long[] depthMeasurements)
        {
            var increases = 0;
            var indexOfLastSummableMeasure = depthMeasurements.Length - 3;
            for (var i = 1; i <= indexOfLastSummableMeasure; i++)
            {
                var overlap = depthMeasurements[i] + depthMeasurements[i + 1];
                var previousWindowSum = overlap + depthMeasurements[i - 1];
                var currentWindowSum = overlap + depthMeasurements[i + 2];
                if (currentWindowSum > previousWindowSum)
                {
                    increases++;
                }
            }

            return increases;
        }
    }
}
