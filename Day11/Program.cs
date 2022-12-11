using System.Diagnostics;

var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var calmingTimer = new Stopwatch();
calmingTimer.Start();

var calming = true;
var parser = new Parser();
(var monkeys, var number) = parser.Parse(input, calming);

var fatherTime = new FatherTime(monkeys);

var rounds = 20;

fatherTime.PassTime(rounds);

var monkeyActivities = monkeys.Select(m => m.Activeness).ToList();

monkeyActivities.Sort();

var monkeyBusiness = monkeyActivities[^1] * monkeyActivities[^2];
calmingTimer.Stop();

Console.WriteLine(monkeyBusiness);

var timer = new Stopwatch();
timer.Start();

var parser2 = new Parser();
var calming2 = false;
(var monkeys2, number) = parser2.Parse(input, calming2);

var fatherTime2 = new FatherTime(monkeys2, number);

var rounds2 = 10000;

fatherTime2.PassTime(rounds2);

var monkeyActivities2 = monkeys2.Select(m => m.Activeness).ToList();

monkeyActivities2.Sort();

long monkeyBusiness2 = monkeyActivities2[^1] * monkeyActivities2[^2];
timer.Stop();

Console.WriteLine(monkeyBusiness2);

Console.WriteLine();
Console.WriteLine($"calming: {calmingTimer.Elapsed.TotalMilliseconds} ms");
Console.WriteLine($"stressful: {timer.Elapsed.TotalMilliseconds} ms");