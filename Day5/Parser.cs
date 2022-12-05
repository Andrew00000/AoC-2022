public class Parser
{
    public (IEnumerable<Stack<char>> crates, IEnumerable<Command> commands) ParseInputToStackColumns(string input)
    {
        var cratesInput = input.Split(Environment.NewLine + Environment.NewLine)[0];
        var commandsInput = input.Split(Environment.NewLine + Environment.NewLine)[1];

        return (ParseCratesInputToStackColumns(cratesInput), ParseCommands(commandsInput));
    }

    public (IEnumerable<string> crates, IEnumerable<Command> commands) ParseInputToStringColumns(string input)
    {
        var cratesInput = input.Split(Environment.NewLine + Environment.NewLine)[0];
        var commandsInput = input.Split(Environment.NewLine + Environment.NewLine)[1];

        return (ParseCratesInputToStringColumns(cratesInput), ParseCommands(commandsInput));
    }

    public IEnumerable<Stack<char>> ParseCratesInputToStackColumns(string cratesInput)
    {
        var columns = new List<Stack<char>>();
        var splitInput = cratesInput.Split(Environment.NewLine);

        for (int i = 0; i < splitInput[0].Length; i += 4)
        {
            var stack = new Stack<char>();

            for (int j = splitInput.Length - 1; j >= 0; j--)
            {
                if (char.IsLetter(splitInput[j][i + 1]))
                {
                    stack.Push(splitInput[j][i + 1]);
                }
            }

            columns.Add(stack);
        }

        return columns;
    }
    public IEnumerable<string> ParseCratesInputToStringColumns(string cratesInput)
    {
        var columns = new List<string>();
        var splitInput = cratesInput.Split(Environment.NewLine);

        for (int i = 0; i < splitInput[0].Length; i += 4)
        {
            var column = "";

            for (int j = splitInput.Length - 1; j >= 0; j--)
            {
                if (char.IsLetter(splitInput[j][i + 1]))
                {
                    column += (splitInput[j][i + 1]);
                }
            }

            columns.Add(column);
        }

        return columns;
    }


    public IEnumerable<Command> ParseCommands(string commandsInput)
    {
        var commandLines = commandsInput.Split(Environment.NewLine);

        var commands = new Command[commandLines.Length];
        
        for (int i = 0; i < commandLines.Length; i++)
        {
            commands[i] = new Command
            {
                From = Int32.Parse(commandLines[i].Split(' ')[3]) - 1,
                To = Int32.Parse(commandLines[i].Split(' ')[5]) - 1,
                Quantity = Int32.Parse(commandLines[i].Split(' ')[1])
            };
        }

        return commands;
    }
}