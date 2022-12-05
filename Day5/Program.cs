using System.Diagnostics;

var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var parser = new Parser();

(var crateColumnStacks, var commands) = parser.ParseInputToStackColumns(input);

var crane = new Crane();

var sortedCrateColumnStacks = crane.SortByMovingOne(crateColumnStacks.ToArray(), commands);

var topCrates = crane.Print(sortedCrateColumnStacks);

Console.WriteLine(topCrates);

var crateColumnStrings = parser.ParseCratesInputToStringColumns(input.Split(Environment.NewLine + Environment.NewLine)[0]);
crateColumnStacks = parser.ParseCratesInputToStackColumns(input.Split(Environment.NewLine + Environment.NewLine)[0]);

var stringTimer = new Stopwatch();
stringTimer.Start();
var sortedCrateColumnStrings = crane.SortByMovingMore(crateColumnStrings.ToArray(), commands);
stringTimer.Stop();

var tempStackTimer = new Stopwatch();
tempStackTimer.Start();
var sortedCrateColumnsStackMovedMore = crane.SortByMovingMore(crateColumnStacks.ToArray(), commands);
tempStackTimer.Stop();

var topCrates22 = crane.Print(sortedCrateColumnsStackMovedMore);
var topCrates21 = crane.Print(sortedCrateColumnStrings);

Console.WriteLine(topCrates21);

Console.WriteLine();
Console.WriteLine(topCrates21 == topCrates22);

Console.WriteLine(stringTimer.Elapsed);
Console.WriteLine(tempStackTimer.Elapsed);