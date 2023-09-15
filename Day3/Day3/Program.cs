var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solutionOne = 7446;
var solutionTwo = 2646;

const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

//Problem One: https://adventofcode.com/2022/day/3

var answerOne = 0;
foreach (var line in input!)
{
    var compartmentSize = line.Length / 2;

    var firstCompartment = line[..(compartmentSize)].ToHashSet();
    var secondCompartment = line[(compartmentSize)..].ToHashSet();

    var itemInBothCompartment = firstCompartment.Intersect(secondCompartment);

    answerOne += alphabet.IndexOf(itemInBothCompartment.First()) + 1;
}

var problemOneResult = solutionOne == answerOne ? $"Yes the answer is {answerOne}"
                                                : $"No the answer isnt {answerOne}";

Console.WriteLine(problemOneResult);



//Problem Two: https://adventofcode.com/2022/day/3

var answerTwo = 0;
for (int i = 0; i < input.Length; i+=3)
{
    var elfOneBagContent = input[i].ToHashSet();
    var elfTwoBagContent = input[i+1].ToHashSet();
    var elfThreeBagContent = input[i+2].ToHashSet();

    var badge = elfOneBagContent.Intersect(elfTwoBagContent).Intersect(elfThreeBagContent);

    answerTwo += alphabet.IndexOf(badge.First()) + 1;
}

var problemTwoResult = solutionTwo == answerTwo ? $"Yes the answer is {answerTwo}"
                                                : $"No the answer isnt {answerTwo}";

Console.WriteLine(problemTwoResult);
