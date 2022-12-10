public class Mover
{
    public void DoTheChacha(IEnumerable<Command> commands, Snek snek)
    {
        foreach (var command in commands)
        {
            command.Execute(snek);
        };
    }

    internal void DoTheTango(IEnumerable<Command> commands, Anaconda anaconda)
    {
        foreach (var command in commands)
        {
            command.Execute(anaconda);
        };
    }
}