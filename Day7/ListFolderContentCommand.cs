namespace Day7;

public class ListFolderContentCommand : ICommands
{
    public HashSet<Folder> FoldersToShow { get; init; } = new();
    public HashSet<Fajl> FajlsToShow { get; init; } = new();

    public ListFolderContentCommand(string[] items)
    {
        foreach (var item in items)
        {
            if (item.StartsWith("dir "))
            {
                FoldersToShow.Add(new Folder { Name = item.Split(' ')[1] });
            }
            else
            {
                FajlsToShow.Add(new Fajl { Name = item.Split(' ')[1], 
                                           Size = Int64.Parse(item.Split(' ')[0]) });
            }
        }
    }

    public void Execute()
    {
        Parser.FillFolderChildren(FoldersToShow);
        Parser.FillFolderFiles(FajlsToShow);
    }
}

