using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day17TrickShot.Physics
{
    internal record class Velocity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Velocity(int xInitial, int yInitial)
        {
            this.X = xInitial;
            this.Y = yInitial;
        }
    }
}
