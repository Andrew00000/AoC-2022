public class Folder
{
    private readonly HashSet<File> files = new();

    public required string Name { get; init; }
    public Folder? Parent { get; set; } = null;
    public HashSet<Folder> Children { get; private set; } = new();
    public long GetSize()
    {
        var size = files.Aggregate(0L, (size, f) => size + f.Size);
        size = Children.Aggregate(size, (size, f) => size + f.GetSize());

        return size;
    }

    public void FillChildren(HashSet<Folder> children)
        => Children.UnionWith(children);

    public void FillFiles(HashSet<File> files)
        => this.files.UnionWith(files);

    public HashSet<Folder> GetAllSubFolders()
    {
        var children = Children;
        var subChildren = new HashSet<Folder>();

        foreach (var child in children)
        {
            subChildren.UnionWith(child.GetAllSubFolders());
        }

        subChildren.UnionWith(children);

        return subChildren;
    }
}