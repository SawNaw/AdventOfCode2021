using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day17TrickShot.PositionData;

namespace AdventOfCode.Day17TrickShot.TargetAreaProcessing
{
    /// <summary>
    /// Represents the target area using max/min x-y coordinates
    /// </summary>
    internal readonly record struct TargetArea : ITargetArea
    {
        public readonly int XMin { get; }
        public readonly int YMin { get; }
        public readonly int XMax { get; }
        public readonly int YMax { get; }

        public TargetArea(int xMin, int xMax, int yMin, int yMax)
        {
            if (xMin > xMax) throw new ArgumentException("Minimum X value cannot be greater than Maximum X value.");
            if (yMin > yMax) throw new ArgumentException("Minimum Y value cannot be greater than Maximum Y value.");

            this.XMin = xMin;
            this.XMax = xMax;
            this.YMin = yMin;
            this.YMax = yMax;
        }

        public bool ContainsPosition(Position pos)
        {
            return (pos.X <= XMax && pos.X >= XMin)
                && (pos.Y <= YMax && pos.Y >= YMin);
        }
    }
}
