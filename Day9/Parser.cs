public class Parser
{
    public IEnumerable<Command> Parse(string[] input)
    {
        var commands = new List<Command>();
        var factory = new CommandFactory();

        foreach (var line in input)
        {
            var direction = line.Split(' ')[0];
            var value = Int32.Parse(line.Split(' ')[1]);

            commands.Add(factory.CreateCommand(direction, value));            
        };

        return commands;
    }
}