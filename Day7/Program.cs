var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var parser = new Parser();

var rootFolder = parser.Parse(input);

var allFolders = rootFolder.GetAllChildrenFoldersAndSubFolders().ToList();

var sum = 0L;

allFolders.Where(f => f.GetSize() <= 100000).Select(f => f.GetSize()).ToList().ForEach(s => sum += s);

Console.WriteLine(sum);

var totalDiskSpace = 70000000;

var requiredDiskSpace = 30000000;

var usedDiskSpace = rootFolder.GetSize();

var freeDiskSpace = totalDiskSpace - usedDiskSpace;

var spaceNeededToBeFreedUp = requiredDiskSpace - freeDiskSpace;

if (spaceNeededToBeFreedUp < 0)
{
    Console.WriteLine("you have enough space...dummy");
}

var sacraficalFolderSize = allFolders.Where(f => f.GetSize() >= spaceNeededToBeFreedUp).Select(f => f.GetSize()).ToList().Min();

Console.WriteLine(sacraficalFolderSize);