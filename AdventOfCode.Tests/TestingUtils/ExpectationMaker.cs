namespace AdventOfCode.Tests.TestingUtils
{
    public static class ExpectationMaker
    {
        public static object[] Expect(int day, string file, long result)
        {
            return new object[] { File.ReadAllText($"Input/Day{day}/{file}.txt"), result };
        }
    }
}
