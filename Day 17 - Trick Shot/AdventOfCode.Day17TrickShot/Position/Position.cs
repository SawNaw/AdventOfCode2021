using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day17TrickShot.PositionData
{
    internal record Position
    {
        internal double X { get; set; }
        internal double Y { get; set; }

        public Position(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        internal double DistanceFrom(Position p2)
        {
            return Math.Sqrt(Math.Pow((this.X - p2.X), 2)
                           + Math.Pow((this.Y - p2.Y), 2));
        }
    }
}
