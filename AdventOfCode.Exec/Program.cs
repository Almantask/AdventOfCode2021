﻿using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Common;
using AdventOfCode.Day1;

namespace AdventOfCode.Exec
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Solve<Day1.Solution>();
            Solve<Day2.Solution>();
        }

        private static void Solve<TAdventOfCodeDay>() where TAdventOfCodeDay : IDaySolution, new()
        {
            new TAdventOfCodeDay().Solve();
        }
    }
}
