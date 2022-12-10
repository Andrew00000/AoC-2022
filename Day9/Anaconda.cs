public class Anaconda
{
    private readonly List<Snek> sneks = new();

    public Anaconda(int length)
    {
        for (int i = 0; i < length; i++)
        {
            sneks.Add(new Snek());
        }
    }

    public int GetTouchedFields()
        => sneks.Last().GetNumberOfTouchedFields();

    public void Move(int y, int x)
    {
        var tempY = y;
        var tempX = x;

        for (int i = 0; i < sneks.Count; i++)
        {
            (tempY, tempX) = sneks[i].HeadMoves(tempY, tempX);
        }
    }
}