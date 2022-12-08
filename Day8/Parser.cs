internal class Parser
{
    public Parser()
    {
    }

    public int[][] Parse(string[] input)
    {
        var table = new int[input.Length][];

        for (int i = 0; i < input.Length; i++)
        {
            table[i] = new int[input[i].Length];

            for (int j = 0; j < input[0].Length; j++)
            {
                table[i][j] = (int)Char.GetNumericValue(input[j][i]);
            }
        }
        
        return table;
    }
}