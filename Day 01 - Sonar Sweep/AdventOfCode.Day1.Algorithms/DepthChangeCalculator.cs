namespace AdventOfCode.Day1.Algorithms
{
    public class DepthChangeCalculator
    {
        public static DepthChanges GetDepthChanges(IReadOnlyCollection<Measurement> measurements)
        {
            if (measurements.Count <= 1)
            {
                return new DepthChanges(new List<DepthChangeType>());
            }

            else
            {
                return ComputeChanges(measurements);
            }
        }

        private static DepthChanges ComputeChanges(IReadOnlyCollection<Measurement> measurements)
        {
            var changes = new List<DepthChangeType>();

            for (int i = 0; i < measurements.Count - 1; i++)
            {
                if (measurements.ElementAt(i + 1).Value > measurements.ElementAt(i).Value)
                {
                    changes.Add(DepthChangeType.Increase);
                }
                else if (measurements.ElementAt(i + 1).Value < measurements.ElementAt(i).Value)
                {
                    changes.Add(DepthChangeType.Decrease);
                }
                else
                {
                    changes.Add(DepthChangeType.NoChange);
                }
            }

            return new DepthChanges(changes);
        }
    }
}