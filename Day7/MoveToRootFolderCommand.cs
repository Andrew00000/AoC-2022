namespace Day7;

public class MoveToRootFolderCommand : ICommands
{
    public void Execute(FileSystem fileSystem)
        => fileSystem.ResetToRootFolder();
}
