namespace AdventOfCode.Day17TrickShot.TargetAreaProcessing
{
    internal static class TargetAreaInputParser
    {
        public static TargetArea Parse(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) throw new InvalidOperationException("Input is empty.");

            var processedString = line.Trim()                         
                                      .Replace("target area: x=", "") 
                                      .Replace(", y=", "..")          
                                      .Split("..")                    
                                      .Select(x => int.Parse(x))
                                      .ToArray();

            return new TargetArea(processedString[0], processedString[1], processedString[2], processedString[3]);
        }
    }
}