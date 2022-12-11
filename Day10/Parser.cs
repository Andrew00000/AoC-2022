using Microsoft.VisualBasic;

internal class Parser
{

    internal IEnumerable<int> Parse(string[] input)
    {
        var ints = new List<int>();

        foreach(var line in input)
        {
            if (line == "noop")
            {
                ints.Add(0);
            }
            else
            {
                ints.Add(0);
                ints.Add(int.Parse(line.Split(' ')[1]));
            }
        }

        return ints;
    }
}