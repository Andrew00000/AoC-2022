using System.Diagnostics;

var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solutionOne = "RTGWZTHLD";
var solutionTwo = "STHGRZZFR";


//Problem One: https://adventofcode.com/2022/day/5

var parser = new Parser();

(var crateColumnStacks, var commands) = parser.ParseInputToStackColumns(input);

var crane = new Crane();

var sortedCrateColumnStacks = crane.SortByMovingOne(crateColumnStacks.ToArray(), commands);

var topCrates = crane.GetTopCrates(sortedCrateColumnStacks);

var problemOneResult = solutionOne == topCrates ? $"Yes the answer is {topCrates}"
                                                : $"No the answer isnt {topCrates}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2022/day/5

var stringTimer = new Stopwatch();
stringTimer.Start();

var crateColumnStrings = parser.ParseCratesInputToStringColumns(input.Split(Environment.NewLine + Environment.NewLine)[0]);

var sortedCrateColumnStrings = crane.SortByMovingMore(crateColumnStrings.ToArray(), commands);
stringTimer.Stop();

var stackTimer = new Stopwatch();
stackTimer.Start();

crateColumnStacks = parser.ParseCratesInputToStackColumns(input.Split(Environment.NewLine + Environment.NewLine)[0]);

var sortedCrateColumnsStackMovedMore = crane.SortByMovingMore(crateColumnStacks.ToArray(), commands);
stackTimer.Stop();

var topCratesWithStrings = crane.GetTopCrates(sortedCrateColumnStrings);
var topCratesWithStacks = crane.GetTopCrates(sortedCrateColumnsStackMovedMore);

var problemTwoResult = solutionTwo == topCratesWithStacks ? $"Yes the answer is {topCratesWithStacks}"
                                                          : $"No the answer isnt {topCratesWithStacks}";

Console.WriteLine(problemTwoResult);

Console.WriteLine();

if (topCratesWithStacks == topCratesWithStrings )
{
    Console.WriteLine("Run comparison between using strings vs using stacks:");

    Console.WriteLine(stringTimer.Elapsed);
    Console.WriteLine(stackTimer.Elapsed);
}
else
{
    Console.WriteLine("Results are different");
}