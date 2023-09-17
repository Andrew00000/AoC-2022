public class Mover
{
    public void DoTheChacha(IEnumerable<Command> commands, IDangerNoodle dangerNoodle)
    {
        foreach (var command in commands)
        {
            command.Execute(dangerNoodle);
        };
    }
}