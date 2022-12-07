using System.Linq;

public class Folder
{
    public required string Name { get; init; }
    public Folder? Parent { get; set; } = null;
    public HashSet<Folder> Children { get; private set; } = new();
    public HashSet<Fajl> Files { get; private set; } = new();

    public long GetSize()
    {
        var size = 0L;
        
        Files.ToList().ForEach(f => size += f.Size);
        Children.ToList().ForEach(f => size += f.GetSize());

        return size;
    }

    public void FillChildren(HashSet<Folder> children)
        => Children = Children.Concat(children).ToHashSet();

    public void FillFiles(HashSet<Fajl> files)
        => Files = Files.Concat(files).ToHashSet();

    public HashSet<Folder> GetAllChildrenFoldersAndSubFolders()
    {
        var children = Children;
        var subChildren = new HashSet<Folder>();

        foreach (var child in children)
        {
            child.GetAllChildrenFoldersAndSubFolders().ToList().ForEach(child => subChildren.Add(child));
        }

        return children = children.Concat(subChildren).ToHashSet();
    }
}