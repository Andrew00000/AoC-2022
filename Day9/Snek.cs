using System.Numerics;

public class Snek
{
    //private readonly Head head = new ();
    private readonly Tail tail = new ();

    public int GetNumberOfTouchedFields()
        => tail.GetNumberOfTouchedFields();

    public void Move(int y, int x)
        => MoveTail(y, x);
    

    private void MoveTail(int y, int x) 
        => tail.HeadMoves(y, x);
}