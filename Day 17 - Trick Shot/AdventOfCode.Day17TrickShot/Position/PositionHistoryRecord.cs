using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day17TrickShot.Physics;

namespace AdventOfCode.Day17TrickShot.PositionData
{
    internal readonly record struct PositionHistoryRecord
    {
        public Position Position { get; }
        public Velocity Velocity { get; }
        public bool IsInsideTargetArea { get; }

        public PositionHistoryRecord(Position position, Velocity velocity, bool isInsideTargetArea)
        {
            this.Position = position;
            this.Velocity = velocity;
            this.IsInsideTargetArea = isInsideTargetArea;
        }
    }
}
