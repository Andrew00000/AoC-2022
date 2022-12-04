internal class Parser
{
    public (Assignment, Assignment) Parse(string input)
        => (new Assignment(Int32.Parse(input.Split(',')[0].Split('-')[0]), Int32.Parse(input.Split(',')[0].Split('-')[1])),
            new Assignment(Int32.Parse(input.Split(',')[1].Split('-')[0]), Int32.Parse(input.Split(',')[1].Split('-')[1])));
}