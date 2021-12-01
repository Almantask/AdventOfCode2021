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
    }
}
