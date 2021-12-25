using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day17TrickShot.PositionData;
using AdventOfCode.Day17TrickShot.Physics;
using AdventOfCode.Day17TrickShot.TargetAreaProcessing;

namespace AdventOfCode.Day17TrickShot.ProbeLaunchSimulation
{
    internal record class ProbeLaunchSimulationResult
    {
        public bool TargetAreaReached { get; }
        public Position CurrentPosition { get; }
        public Velocity CurrentVelocity { get; }
        public ITargetArea TargetArea { get; }
        public PositionHistory TravelLog { get; }
        public double HighestAltitudeReached { get; }

        public ProbeLaunchSimulationResult(bool targetAreaReached,
                                           Position currentPosition,
                                           Velocity currentVelocity,
                                           ITargetArea targetArea,
                                           PositionHistory travelLog,
                                           double highestAltitudeReached)
        {
            this.TargetAreaReached = targetAreaReached;
            this.CurrentPosition = currentPosition;
            this.CurrentVelocity = currentVelocity;
            this.TargetArea = targetArea;
            this.TravelLog = travelLog;
            this.HighestAltitudeReached = highestAltitudeReached;
        }
    }
}
