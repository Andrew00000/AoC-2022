public class Crane
{
    public string GetTopCrates(IEnumerable<Stack<char>> sortedCrates)
    {
        var topText = "";

        foreach (var column in sortedCrates)
        {
            topText += column.Peek();
        }

        return topText;
    }

    public string GetTopCrates(IEnumerable<string> sortedCrates)
    {
        var topText = "";

        foreach (var column in sortedCrates)
        {
            topText += column[^1];
        }

        return topText;
    }

    public IEnumerable<Stack<char>> SortByMovingOne(Stack<char>[] crates, IEnumerable<Command> commands)
    {
        foreach (var command in commands)
        {
            for (int i = 0; i < command.Quantity; i++)
            {
                crates[command.To].Push(crates[command.From].Pop());
            }
        }

        return crates;
    }

    public IEnumerable<string> SortByMovingMore(String[] crates, IEnumerable<Command> commands)
    {
        foreach (var command in commands)
        {
            crates[command.To] = crates[command.To] + crates[command.From][^command.Quantity..];
            crates[command.From] = crates[command.From][..^command.Quantity];
        }

        return crates;
    }

    public IEnumerable<Stack<char>> SortByMovingMore(Stack<char>[] crates, IEnumerable<Command> commands)
    {
        foreach (var command in commands)
        {
            var temp = new Stack<char>();
            
            for (int i = 0; i < command.Quantity; i++)
            {
                temp.Push(crates[command.From].Pop());
            }

            for (int i = 0; i < command.Quantity; i++)
            {
                crates[command.To].Push(temp.Pop());
            }
        }

        return crates;
    }
}