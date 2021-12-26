using AdventOfCode.Day3BinaryDiagnostic.RateCalculators;
using AdventOfCode.Day3BinaryDiagnostic.DataStructures;
using AdventOfCode.Day3BinaryDiagnostic.Console;

// See https://aka.ms/new-console-template for more information


string filePath = $"{Directory.GetCurrentDirectory()}\\PuzzleInput.txt";

var powerConsumptionCalculator = new PowerConsumptionCalculator(new RateCalculator(new DiagnosticReport(filePath)));
int answerToPartOne = powerConsumptionCalculator.Calculate();

char[] array = new char[] { '1', '1', '1', '0', '0', '0' };
Console.WriteLine($"Most commmon: {MostCommon.GetMostCommon(array)}");
Console.WriteLine($"Least commmon: {MostCommon.GetLeastCommon(array)}");

Console.WriteLine("Answer to Part One");
Console.WriteLine("--------------------");
Console.WriteLine($"The power consumption is: {answerToPartOne}");
Console.WriteLine();
Console.WriteLine("Answer to Part Two");
Console.WriteLine("--------------------");
//Console.WriteLine($"The power consumption is: {answerToPartOne}");