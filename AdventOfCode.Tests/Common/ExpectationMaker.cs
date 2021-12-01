﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Common;

namespace AdventOfCode.Tests.Common
{
    public static class ExpectationMaker
    {
        public static object[] Expect(int day, string file, int result)
        {
            return new object[] { File.ReadAllText($"Input/Day{day}/{file}.txt"), result };
        }
    }
}