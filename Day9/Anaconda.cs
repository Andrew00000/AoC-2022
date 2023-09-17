public class Anaconda : IDangerNoodle
{
    private readonly List<Snekk> snekks = new();

    public Anaconda(int length)
    {
        for (int i = 0; i < length; i++)
        {
            snekks.Add(new Snekk());
        }
    }

    public int GetNumberOfTouchedFields()
        => snekks.Last().GetNumberOfTouchedFields();

    public void Move(int y, int x)
    {
        var tempY = y;
        var tempX = x;

        for (int i = 0; i < snekks.Count; i++)
        {
            (tempY, tempX) = snekks[i].HeadMoves(tempY, tempX);
        }
    }
}