public class FileSystem
{
    private Folder currentFolder;
    public Folder Root { get; init; } = new() { Name = "root" };

    public FileSystem()
    {
        currentFolder= Root;
    }

    public void FillFolderChildren(HashSet<Folder> children)
    {
        children.ToList().ForEach(child => child.Parent = currentFolder);
        currentFolder.FillChildren(children);
    }

    public void FillFolderFiles(HashSet<File> files)
        => currentFolder.FillFiles(files);

    public void GoUpOneFolder()
        => currentFolder = currentFolder.Parent ?? throw new ArgumentException("That was insensitive, this folder doesnt have any parents");

    public void MoveIntoChild(string childName)
        => currentFolder = currentFolder.Children.First(x => x.Name == childName);

    public  void ResetToRootFolder()
        => currentFolder = Root;
}