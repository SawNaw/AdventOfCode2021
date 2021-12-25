using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode.Day2.Algorithms
{
    public static class InputParser
    {
        public static string[] Parse(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
