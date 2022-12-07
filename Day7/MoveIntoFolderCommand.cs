using System.Windows.Input;

namespace Day7;

public class MoveIntoFolderCommand : ICommands
{
    private string childName = "";

    public MoveIntoFolderCommand(string childName)
    {
        this.childName = childName;
    }

    public void Execute(FileSystem fileSystem)
        => fileSystem.MoveIntoChild(childName);
}
