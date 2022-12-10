public class Head
{
    private int y = 0;
    private int x = 0;

    public (int y, int x) Move(int y, int x)
    {
        this.y += y;
        this.x += x;

        return (y, x);
    }
}