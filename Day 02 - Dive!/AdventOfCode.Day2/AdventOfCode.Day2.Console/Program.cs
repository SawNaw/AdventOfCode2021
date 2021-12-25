using AdventOfCode.Day2.Algorithms;

string filePath = $"{Directory.GetCurrentDirectory()}\\Input.txt";
var lines = InputParser.Parse(filePath);

var submarine = new Submarine();

foreach (var line in lines)
{
    var command = line.Split(' ');
    string direction = command[0].ToLower();
    int displacement = int.Parse(command[1]);
    switch (direction)
    {
        case "forward":
            submarine.Forward(displacement);
            break;
        case "up":
            submarine.Up(displacement);
            break;
        case "down":
            submarine.Down(displacement);
            break;
        default:
            throw new InvalidOperationException($"{direction} is not a known direction.");
    }
}

Console.WriteLine(submarine.HorizontalPositionTimesDepth);