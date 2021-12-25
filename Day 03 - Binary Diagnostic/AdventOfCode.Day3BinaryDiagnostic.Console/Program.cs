using AdventOfCode.Day3BinaryDiagnostic.RateCalculators;
using AdventOfCode.Day3BinaryDiagnostic.DataStructures;

// See https://aka.ms/new-console-template for more information


string filePath = $"{Directory.GetCurrentDirectory()}\\PuzzleInput.txt";

var reportReader = new DiagnosticReport(filePath);

Console.WriteLine("Bye!");