public class FileSystem
{
    private readonly Folder root = new() { Name = "root" };
    private Folder currentFolder;

    public FileSystem()
    {
        currentFolder= root;
    }
    public void ChangeCurrentFolder(Folder newCurrent)
        => currentFolder = newCurrent;

    public void FillFolderChildren(HashSet<Folder> children)
    {
        children.ToList().ForEach(child => child.Parent = currentFolder);
        currentFolder.FillChildren(children);
    }

    public void FillFolderFiles(HashSet<Fajl> files)
    {
        currentFolder.FillFiles(files);
    }

    public void GoUpOneFolder()
        => currentFolder = currentFolder.Parent ?? throw new ArgumentException("You made a booboo");

    public void MoveIntoChild(string childName)
        => currentFolder = currentFolder.Children.First(x => x.Name == childName);

    public  void ResetToRootFolder()
        => currentFolder = root;

    public Folder GetRootFolder()
        => root;
}