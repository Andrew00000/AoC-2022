using Day7;
using System.Text.RegularExpressions;

public static class Parser
{
    private static Folder root = new() { Name = "root" };
    private static Folder currentFolder = root;

    public static Folder Parse(string input)
    {
        var commands = ParseToCommands(input);

        commands.ForEach(c => c.Execute());

        return root;
    }

    private static List<ICommands> ParseToCommands(string input)
    {
        var commandChunks = input.Split("$ ");
        var commandList = new List<ICommands>();

        foreach (var command in commandChunks[1..])
        {
            if (command.StartsWith("cd /"))
            {
                commandList.Add(new MoveToRootFolderCommand());
            }
            else if (command.StartsWith("cd .."))
            {
                commandList.Add(new MoveOutOfFolderCommand(Regex.Matches(command, $" ..").Count));
            }
            else if (command.StartsWith("cd "))
            {
                commandList.Add(new MoveIntoFolderCommand(command.Split("cd ")[1].TrimEnd()));
            }
            else if (command.StartsWith("ls"))
            {
                var content = command.Split(Environment.NewLine);
                content = content.Where(c => c !="" && c != "ls").ToArray();
                commandList.Add(new ListFolderContentCommand(content));
            }
            else
            {
                throw new ArgumentException("Suddenly a booboo appears");
            }
        }

        return commandList;
    }

    public static void ChangeCurrentFolder(Folder newCurrent)
        => currentFolder = newCurrent;

    public static void ResetToRootFolder()
        => currentFolder = root;

    public static void GoUpOneFolder()
        => currentFolder = currentFolder.Parent ?? throw new ArgumentException("You made a booboo");

    public static void FillFolderChildren(HashSet<Folder> children)
    {
        children.ToList().ForEach(child => child.Parent= currentFolder);
        currentFolder.FillChildren(children);        
    }

    public static void FillFolderFiles(HashSet<Fajl> files)
    {
        currentFolder.FillFiles(files);
    }

    public static void MoveIntoChild(string childName)
        => currentFolder = currentFolder.Children.First(x => x.Name == childName);
}