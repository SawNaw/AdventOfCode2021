using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day17TrickShot.PositionData;

namespace AdventOfCode.Day17TrickShot.TargetAreaProcessing
{
    internal interface ITargetArea
    {
        public int XMin { get; }
        public int YMin { get; }
        public int XMax { get; }
        public int YMax { get; }


        bool ContainsPosition(Position pos);
    }
}
