using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day17TrickShot.PositionData
{
    internal class PositionHistory
    {
        private List<PositionHistoryRecord> _pastPositions { get; } = new();
        public IReadOnlyCollection<PositionHistoryRecord> PastPositions => _pastPositions;

        public double LowestX { get; private set; }
        public double LowestY { get; private set; }
        public double HighestX { get; private set; }
        public double HighestY { get; private set; }

        public void Add(PositionHistoryRecord rec)
        {
            _pastPositions.Add(rec);
            UpdateLowestAndHighest(rec.Position);
        }

        private void UpdateLowestAndHighest(Position pos)
        {
            UpdateLowestAndHighestForX(pos);
            UpdateLowestAndHighestForY(pos);
        }

        private void UpdateLowestAndHighestForY(Position pos)
        {
            if (pos.Y < LowestY)
            {
                LowestY = pos.Y;
            }
            else if (pos.Y > HighestY)
            {
                HighestY = pos.Y;
            }
        }

        private void UpdateLowestAndHighestForX(Position pos)
        {
            if (pos.X < LowestX)
            {
                LowestX = pos.X;
            }
            else if (pos.X > HighestX)
            {
                HighestX = pos.X;
            }
        }
    }
}
