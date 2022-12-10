public class Command
{
    private readonly int y;
    private readonly int x;
    private readonly int repeat;

    public Command(int repeat, int y, int x)
    {
        this.repeat = repeat;
        this.y = y;
        this.x = x;
    }

    public void Execute(Snek snek)
    {
        for (int i = 0; i < repeat; i++)
        {
            snek.Move(y, x);
        }
    }

    public void Execute(Anaconda anaconda)
    {
        for (int i = 0; i < repeat; i++)
        {
            anaconda.Move(y, x);
        }
    }
}