var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solutionOne = 1812;
var solutionTwo = 315495;


//Problem One: https://adventofcode.com/2022/day/8

var parser = new Parser();

var table = parser.Parse(input);

var inspector = new Inspector(table);

var visibilityTable = inspector.GetVisibility();

var sum = 0;

foreach (var row in visibilityTable)
{
    foreach (var spot in row)
    {
        sum += Convert.ToInt32(spot);
    }
}

var problemOneResult = solutionOne == sum ? $"Yes the answer is {sum}"
                                          : $"No the answer isnt {sum}";

Console.WriteLine(problemOneResult);


//Problem Two: https://adventofcode.com/2022/day/8

var scoreTable = inspector.GetScenicScore();

var max = 0L;

foreach (var row in scoreTable)
{
    foreach (var spot in row)
    {
        max = (max > spot) ? max : spot;
    }
}

var problemTwoResult = solutionTwo == max ? $"Yes the answer is {max}"
                                          : $"No the answer isnt {max}";

Console.WriteLine(problemTwoResult);