public class Anaconda
{
    private List<Snek> sneks = new();
    private CommandFactory factory;

    public Anaconda(int length, CommandFactory factory)
    {
        for (int i = 0; i < length; i++)
        {
            sneks.Add(new Snek());
        }

        this.factory = factory;
    }

    public int GetTouchedFields()
        => sneks.Last().GetNumberOfTouchedFields();

    internal void Move(int y, int x)
    {
    }
}