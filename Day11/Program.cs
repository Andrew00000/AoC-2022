using System.Diagnostics;

var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solutionOne = 78678;
var solutionTwo = 15333249714;


//Problem One: https://adventofcode.com/2022/day/11

var calmingTimer = new Stopwatch();
calmingTimer.Start();

var isUltraCoolOn = false;
var interestDropRate = 3;
var parser = new Parser();
var monkeys = parser.Parse(input, isUltraCoolOn, interestDropRate);

var fatherTime = new FatherTime(monkeys);

var rounds = 20;

fatherTime.PassTime(rounds);

var monkeyBusiness = monkeys.OrderByDescending(m => m.Activeness).Take(2).Aggregate(1L, (product, m) => product * m.Activeness);
calmingTimer.Stop();


var problemOneResult = solutionOne == monkeyBusiness ? $"Yes the answer is {monkeyBusiness}"
                                                     : $"No the answer isnt {monkeyBusiness}";

Console.WriteLine(problemOneResult);


//Problem Two: https://adventofcode.com/2022/day/11

var timer = new Stopwatch();
timer.Start();

var parser2 = new Parser();
var is2Cool4School = true;
var monkeys2 = parser2.Parse(input, is2Cool4School);

var fatherTime2 = new FatherTime(monkeys2);

var rounds2 = 10000;

fatherTime2.PassTime(rounds2);

long monkeyBusiness2 = monkeys2.OrderByDescending(m => m.Activeness).Take(2).Aggregate(1L, (product, m) => product * m.Activeness);
timer.Stop();

var problemTwoResult = solutionTwo == monkeyBusiness2 ? $"Yes the answer is {monkeyBusiness2}"
                                                      : $"No the answer isnt {monkeyBusiness2}";

Console.WriteLine(problemTwoResult);

Console.WriteLine();
Console.WriteLine($"calming: \t{calmingTimer.Elapsed.TotalMilliseconds} ms");
Console.WriteLine($"stressful: \t{timer.Elapsed.TotalMilliseconds} ms");