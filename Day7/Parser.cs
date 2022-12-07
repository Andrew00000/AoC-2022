using Day7;
using System.Text.RegularExpressions;

public class Parser
{
    private FileSystem fileSystem = new();
    public Folder Parse(string input)
    {
        var commands = ParseToCommands(input);

        commands.ForEach(c => c.Execute(fileSystem));

        return fileSystem.GetRootFolder();
    }

    private List<ICommands> ParseToCommands(string input)
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
}