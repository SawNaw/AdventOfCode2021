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
    internal class ProbeLaunchSimulator
    {
        public double HighestAltitudeReached { get; private set; }

        public Position InitialPosition { get; }
        public Position PreviousPosition { get; }
        public Position CurrentPosition { get; }

        public Velocity InitialVelocity { get; }
        public Velocity CurrentVelocity { get; }

        public PositionHistory PositionHistory { get; }

        public ITargetArea TargetArea { get; }
        public bool IsInsideTargetArea => TargetArea.ContainsPosition(CurrentPosition);

        private bool _targetAreaReached = false;
        public bool TargetAreaReached => _targetAreaReached;
        public int StepCounter { get; private set; } = 0;

        public ProbeLaunchSimulator(Velocity initialVelocity, ITargetArea targetArea)
        {
            this.TargetArea = targetArea;

            // Initialize position and velocity;
            PreviousPosition = new Position(0, 0);
            InitialPosition = new Position(0, 0);
            CurrentPosition = new Position(0, 0);
            InitialVelocity = initialVelocity;
            CurrentVelocity = initialVelocity;

            // Initialize travel log
            PositionHistory = new PositionHistory();
            var positionHistoryRecord = new PositionHistoryRecord(InitialPosition, InitialVelocity, targetArea.ContainsPosition(CurrentPosition));
            PositionHistory.Add(positionHistoryRecord);
        }

        public void Step()
        {
            StepCounter++;

            PreviousPosition.X = CurrentPosition.X;
            PreviousPosition.Y = CurrentPosition.Y;

            CurrentPosition.X += CurrentVelocity.X;
            CurrentPosition.Y += CurrentVelocity.Y;

            if (IsInsideTargetArea && _targetAreaReached == false)
            {
                _targetAreaReached = true;
            }

            if (CurrentPosition.Y > HighestAltitudeReached)
            {
                HighestAltitudeReached = CurrentPosition.Y;
            }

            PositionHistory.Add(new PositionHistoryRecord(new Position(CurrentPosition.X, CurrentPosition.Y),
                                                          new Velocity(CurrentVelocity.X, CurrentVelocity.Y),
                                                          this.TargetArea.ContainsPosition(CurrentPosition)));

            ApplyDrag();
        }

        public void StepMultiple(int numberOfSteps)
        {
            if (numberOfSteps == 0) return;

            for (int i = 1; i <= numberOfSteps; i++)
            {
                Step();
            }
        }

        public ProbeLaunchSimulationResult StepUntilConfirmedHitOrMiss()
        {
            while (!IsFallingAwayFromTarget())
            {
                Step();

                if (_targetAreaReached)
                {
                    return new ProbeLaunchSimulationResult(true, CurrentPosition, CurrentVelocity, TargetArea, PositionHistory, HighestAltitudeReached);
                }
            }

            return new ProbeLaunchSimulationResult(false, CurrentPosition, CurrentVelocity, TargetArea, PositionHistory, HighestAltitudeReached);
        }

        private bool IsFallingAwayFromTarget()
        {
            Position centerOfTarget = CalculateTargetCenter();

            double previousDistanceToTarget = PreviousPosition.DistanceFrom(centerOfTarget);
            double currentDistanceToTarget = CurrentPosition.DistanceFrom(centerOfTarget);

            return IsFalling() && (previousDistanceToTarget < currentDistanceToTarget);
        }

        private bool IsFalling()
        {
            return CurrentPosition.Y < PreviousPosition.Y;
        }

        private Position CalculateTargetCenter()
        {
            int xCoordinate = (TargetArea.XMax + TargetArea.XMin) / 2; // the decimal places won't be stored, so expect some loss of precision
            int yCoordinate = (TargetArea.YMax + TargetArea.YMin) / 2;

            return new Position(xCoordinate, yCoordinate);
        }

        private void ApplyDrag()
        {
            ApplyXComponentDrag();
            ApplyYComponentDrag();
        }

        private void ApplyXComponentDrag()
        {
            if (CurrentVelocity.X < 0)
            {
                CurrentVelocity.X++;
            }
            else if (CurrentVelocity.X > 0)
            {
                CurrentVelocity.X--;
            }
        }

        private void ApplyYComponentDrag()
        {
            CurrentVelocity.Y--;
        }
    }
}
