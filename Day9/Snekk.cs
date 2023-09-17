public class Snekk : IDangerNoodle
{
    private int diffToHeady = 0;
    private int diffToHeadx = 0;
    private int y = 0;
    private int x = 0;

    private readonly HashSet<(int, int)> touchedFields = new() { (0,0) };

    public int GetNumberOfTouchedFields()
        => touchedFields.Count;

    public void Move(int moveY, int moveX)
    {
        diffToHeady += moveY;
        diffToHeadx += moveX;

        if (IsTouching(diffToHeady, diffToHeadx))
        {
            return;
        }
        else if (ShouldItMoveOrtogonally(diffToHeady, diffToHeadx))
        {
            MoveOrtogonally();
        }
        else if (ShouldItMoveDiagonally(diffToHeady, diffToHeadx)) 
        {
            MoveDiagonally();
        }
        else
        {
            throw new ArgumentException("EEEERRRROOOORRRR, HORRRROOORRR, EEEERRROOOORRR");
        }

        touchedFields.Add((y, x));
    }

    public (int movedY, int movedX) HeadMoves(int moveY, int moveX)
    {
        var oldY = y;
        var oldX = x;

        Move(moveY, moveX);

        return (oldY - y, oldX - x);
    }

    private void MoveOrtogonally()
    {
        y += diffToHeady / 2;
        x += diffToHeadx / 2;

        diffToHeady /= 2;
        diffToHeadx /= 2;
    }

    private void MoveDiagonally()
    {
        if (Math.Abs(diffToHeady) == Math.Abs(diffToHeadx))
        {
            y += diffToHeady / 2;
            x += diffToHeadx / 2;

            diffToHeady /= 2;
            diffToHeadx /= 2;
        }
        else if (Math.Abs(diffToHeady) > Math.Abs(diffToHeadx))
        {
            y += diffToHeady / 2;
            x += diffToHeadx;

            diffToHeady /= 2;
            diffToHeadx = 0;
        }
        else 
        {
            y += diffToHeady;
            x += diffToHeadx / 2;

            diffToHeady = 0;
            diffToHeadx /= 2;
        } 
    }

    private bool IsTouching(int diffToHeady, int diffToHeadx)
        => Math.Abs(diffToHeady) <= 1 && Math.Abs(diffToHeadx) <= 1;

    private bool ShouldItMoveOrtogonally(int diffToHeady, int diffToHeadx)
        => Math.Abs(diffToHeady) + Math.Abs(diffToHeadx) == 2;

    private bool ShouldItMoveDiagonally(int diffToHeady, int diffToHeadx)
        => Math.Abs(diffToHeady) + Math.Abs(diffToHeadx) == 3
        || (Math.Abs(diffToHeady) == 2 && Math.Abs(diffToHeadx) == 2);

}