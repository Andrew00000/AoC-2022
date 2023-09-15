var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solutionOne = 475;
var solutionTwo = 825;


//Problem One: https://adventofcode.com/2022/day/4

var parser = new Parser();
var pairAssigments = new List<(Assignment, Assignment)>();

foreach (var line in input)
{
    pairAssigments.Add(parser.Parse(line));
}

var numberOfFullContains = pairAssigments.Where(v => v.Item1.IsContatining(v.Item2) || v.Item2.IsContatining(v.Item1)).Count();

var problemOneResult = solutionOne == numberOfFullContains ? $"Yes the answer is {numberOfFullContains}"
                                                           : $"No the answer isnt {numberOfFullContains}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2022/day/4

var numberOfOverlappingPairs = pairAssigments.Where(v => v.Item1.IsOverLapping(v.Item2)).Count();

var problemTwoResult = solutionTwo == numberOfOverlappingPairs ? $"Yes the answer is {numberOfOverlappingPairs}"
                                                               : $"No the answer isnt {numberOfOverlappingPairs}";

Console.WriteLine(problemTwoResult);
