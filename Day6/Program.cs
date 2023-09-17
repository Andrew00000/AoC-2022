using Day6;
using System.Diagnostics;

var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt").ToArray();
var solutionOne = 1876;
var solutionTwo = 2202;


//Problem One: https://adventofcode.com/2022/day/6

var setFinder = new MarkerFinder(new WithSets());
var queueFinder = new MarkerFinder(new WithQueue());


var indexOfMarker = setFinder.FindMarker(input, 4);

var problemOneResult = solutionOne == indexOfMarker ? $"Yes the answer is {indexOfMarker}"
                                                    : $"No the answer isnt {indexOfMarker}";

Console.WriteLine(problemOneResult);


//Problem Two: https://adventofcode.com/2022/day/6

var setTimer = new Stopwatch();
setTimer.Start();
var indexOfMessageSet = setFinder.FindMarker(input, 14);
setTimer.Stop();

var queueTimer = new Stopwatch();
queueTimer.Start();
var indexOfMessageQueue = queueFinder.FindMarker(input, 14);
queueTimer.Stop();

var problemTwoResult = solutionTwo == indexOfMessageQueue ? $"Yes the answer is {indexOfMessageQueue}"
                                                          : $"No the answer isnt {indexOfMessageQueue}";

Console.WriteLine(problemTwoResult);

Console.WriteLine();

if (indexOfMessageSet == indexOfMessageQueue)
{
    Console.WriteLine("Running time comparison between using sets vs using queue:");

    Console.WriteLine($"Using sets: \t {setTimer.Elapsed.TotalMilliseconds} ms");
    Console.WriteLine($"Using queue: \t {queueTimer.Elapsed.TotalMilliseconds} ms");
}
else
{
    Console.WriteLine("Results are different");
}