namespace Day7;

public class ListFolderContentCommand : ICommands
{
    private readonly HashSet<Folder> folders = new();
    private readonly HashSet<File> files = new();

    public ListFolderContentCommand(string[] items)
    {
        foreach (var item in items)
        {
            if (item.StartsWith("dir "))
            {
                folders.Add(new Folder { Name = item.Split(' ')[1] });
            }
            else
            {
                files.Add(new File { Name = item.Split(' ')[1], 
                                           Size = Int64.Parse(item.Split(' ')[0]) });
            }
        }
    }

    public void Execute(FileSystem fileSystem)
    {
        fileSystem.FillFolderChildren(folders);
        fileSystem.FillFolderFiles(files);
    }
}

