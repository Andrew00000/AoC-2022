internal class Parser
{
    internal List<(List<int>, List<int>)> Parse(string input)
    {
        var parsedPairs = new List<(List<int>, List<int>)>();


        var pairs = input.Split(Environment.NewLine + Environment.NewLine);

        foreach (var pair in pairs)
        {
            parsedPairs.Add((ParsePocket(pair.Split(Environment.NewLine)[0]), ParsePocket(pair.Split(Environment.NewLine)[1])));
        }

        return parsedPairs;
    }

    private List<int> ParsePocket(string pocket)
    {
        var parsedContent = new List<int>();

        if (pocket == "[]")
        {
            parsedContent.Add(0);

            return parsedContent;
        }
        var prepedContentStart = pocket.StartsWith("[") ? pocket.Substring(1) : pocket;
        var prepedContent = prepedContentStart.EndsWith("]") ? prepedContentStart[..^1] : prepedContentStart;
        
        var content = prepedContent.Split(',').ToList();

        foreach (var item in content)
        {
            if (item == "[]")
            {
                parsedContent.Add(0);
            }
            else if (item.StartsWith('['))
            {
                var itemContent = ParsePocket(item);

                parsedContent.AddRange(itemContent);
            }
            else if (item.EndsWith(']'))
            {
                parsedContent.Add(int.Parse(item.TrimEnd(']')));
            }
            else
            {
                parsedContent.Add(int.Parse(item));
            }

        }

        return parsedContent;
    }
}