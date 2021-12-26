using AdventOfCode.Day3BinaryDiagnostic.DataStructures;
using AdventOfCode.Day3BinaryDiagnostic.RateCalculators;

// See https://aka.ms/new-console-template for more information


string filePath = $"{Directory.GetCurrentDirectory()}\\PuzzleInput.txt";

var powerConsumptionCalculator = new PowerConsumptionCalculator(new GammaEpsilonRateCalculator(new DiagnosticReport(filePath)));
int answerToPartOne = powerConsumptionCalculator.Calculate();

var lifeSupportRatingCalculator = new LifeSupportRatingCalculator(new OxygenCO2RatingCalculator(new DiagnosticReport(filePath)));
int answerToPartTwo = lifeSupportRatingCalculator.Calculate();

Console.WriteLine("Answer to Part One");
Console.WriteLine("--------------------");
Console.WriteLine($"The power consumption is: {answerToPartOne}");
Console.WriteLine();
Console.WriteLine("Answer to Part Two");
Console.WriteLine("--------------------");
Console.WriteLine($"The life support rating is: {answerToPartTwo}");