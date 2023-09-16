var input = System.IO.File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solutionOne = 1444896;
var solutionTwo = 404395;


//Problem One: https://adventofcode.com/2022/day/7

var parser = new Parser();

var rootFolder = parser.Parse(input);

var allFolders = rootFolder.GetAllSubFolders();

var sum =  allFolders.Where(f => f.GetSize() <= 100000).Aggregate(0L, (sum, f) => sum + f.GetSize());

var problemOneResult = solutionOne == sum ? $"Yes the answer is {sum}"
                                          : $"No the answer isnt {sum}";

Console.WriteLine(problemOneResult);


//Problem Two: https://adventofcode.com/2022/day/7

var totalDiskSpace = 70000000;

var requiredDiskSpace = 30000000;

var usedDiskSpace = rootFolder.GetSize();

var freeDiskSpace = totalDiskSpace - usedDiskSpace;

var spaceNeededToBeFreedUp = requiredDiskSpace - freeDiskSpace;

if (spaceNeededToBeFreedUp < 0)
{
    Console.WriteLine("You have enough space dummy");
}

var sacrificalFolderSize = allFolders.Where(f => f.GetSize() >= spaceNeededToBeFreedUp).Min(f => f.GetSize());

var problemTwoResult = solutionTwo == sacrificalFolderSize ? $"Yes the answer is {sacrificalFolderSize}"
                                                           : $"No the answer isnt {sacrificalFolderSize}";

Console.WriteLine(problemTwoResult);