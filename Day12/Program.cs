var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solutionOne = 468;
var solutionTwo = 459;


//Problem One: https://adventofcode.com/2022/day/12


var parser = new Parser();

(var map, var start, var end) = parser.Parse(input);

var answerOne = map.CalculateShortestRoute(start, end);

var problemOneResult = solutionOne == answerOne ? $"Yes the answer is {answerOne}"
                                                : $"No the answer isnt {answerOne}";

Console.WriteLine(problemOneResult);


//Problem Two: https://adventofcode.com/2022/day/12

(map, var starts, end) = parser.Parse2(input);

var routes = new HashSet<int>();

foreach (var startingPoint in starts)
{
    routes.Add(map.CalculateShortestRoute(startingPoint, end));
}

var answerTwo = routes.Min();
var problemTwoResult = solutionTwo == answerTwo ? $"Yes the answer is {answerTwo}"
                                                : $"No the answer isnt {answerTwo}";

Console.WriteLine(problemTwoResult);