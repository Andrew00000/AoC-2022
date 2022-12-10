public class CommandFactory
{
    public Command CreateCommand(string direction, int value)
    {
        return direction switch
        {
            "U" => new Command( value, -1, 0 ),
            "D" => new Command( value, 1, 0 ),
            "L" => new Command( value, 0, -1 ),
            "R" => new Command( value, 0, 1 ),
            _ => throw new ArgumentException("what is this??? this is not valid input!!! bad developer!"),
        };
    }
}