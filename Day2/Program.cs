using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solution1 = 9241;
var solution2 = 14610;

if (input is null)
{
    Console.WriteLine("Input missing");
}


//Problem One: https://adventofcode.com/2022/day/2

var scoresDictionary = new Dictionary<string, int>
{
    { "A X", 4 },
    { "A Y", 8 },
    { "A Z", 3 },

    { "B X", 1 },
    { "B Y", 5 },
    { "B Z", 9 },

    { "C X", 7 },
    { "C Y", 2 },
    { "C Z", 6 }
};

var sum = input.Aggregate(0, (x, line) => x + scoresDictionary[line]);

var problemOneResult = solution1 == sum ? $"Yes the answer is {sum}"
                                        : $"No the answer isnt {sum}";

Console.WriteLine(problemOneResult);

//Problem 2: https://adventofcode.com/2022/day/2

var modifiedScoresDictionary = new Dictionary<string, int>
{
    { "A X", 3 },
    { "A Y", 4 },
    { "A Z", 8 },

    { "B X", 1 },
    { "B Y", 5 },
    { "B Z", 9 },

    { "C X", 2 },
    { "C Y", 6 },
    { "C Z", 7 }
};

var sum2 = input.Aggregate(0, (x, line) => x + modifiedScoresDictionary[line]);

var problemTwoResult = solution2 == sum2 ? $"Yes the answer is {sum2}"
                                         : $"No the answer isnt {sum2}";

Console.WriteLine(problemTwoResult);



