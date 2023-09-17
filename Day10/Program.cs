using System.Diagnostics;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solutionOne = 12740;
//var solutionTwo = "RBPARAGF";


//Problem One: https://adventofcode.com/2022/day/10

var partOneTimer = new Stopwatch();
partOneTimer.Start();
var parser = new Parser();

var ints = parser.Parse(input).ToArray();
var calculator = new Calculator();

calculator.Calculate(ints);
partOneTimer.Stop();

var problemOneResult = solutionOne == calculator.GetSolution() ? $"Yes the answer is {calculator.GetSolution()}"
                                                               : $"No the answer isnt {calculator.GetSolution()}";

Console.WriteLine(problemOneResult);


//Problem Two: https://adventofcode.com/2022/day/10

var partTwoTimer = new Stopwatch();
partTwoTimer.Start();
var parserTwo = new Parser();

var ints2 = parserTwo.Parse(input).ToArray();
var calculator2 = new Calculator();

Console.WriteLine("Solution part two:");
calculator2.Print(ints2);
partTwoTimer.Stop();

Console.WriteLine();
Console.WriteLine($"Part one took: {partOneTimer.Elapsed.TotalMilliseconds} ms");
Console.WriteLine($"Part two took: {partTwoTimer.Elapsed.TotalMilliseconds} ms");