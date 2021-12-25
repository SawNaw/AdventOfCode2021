using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day1.Algorithms
{
    public class DepthChanges
    {
        public IReadOnlyCollection<DepthChangeType> ChangeSequence;
        public DepthChanges(ICollection<DepthChangeType> sequence)
        {
            this.ChangeSequence = sequence.ToList();
        }
    }
}
