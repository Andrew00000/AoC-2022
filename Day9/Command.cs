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

    public void Execute(IDangerNoodle dangerNoodle)
    {
        for (int i = 0; i < repeat; i++)
        {
            dangerNoodle.Move(y, x);
        }
    }
}