internal class Parser
{
    internal (Map, (int startY, int startX), (int endY, int endX)) Parse(string[] input)
    {
        var intTable = new int[input.Length][];

        var start = (-1, -1);
        var end = (-1, -1);

        for (int i = 0; i < input.Length; i++)
        {
            intTable[i] = new int[input[i].Length];

            for (int j = 0; j < input[i].Length; j++)
            {
                if (input[i][j] == 'S')
                {
                    start = (i, j);
                    intTable[i][j] = 0;
                }
                else if(input[i][j] == 'E')
                {
                    end = (i, j);
                    intTable[i][j] = 'z' - 'a';
                }
                else
                {
                    intTable[i][j] = input[i][j] - 'a';
                }
            }
        }

        if (start == (-1, -1) || end == (-1, -1))
        {
            throw new ArgumentException("WAAAAAAAAAAAA");
        }

        return (new Map(intTable), start, end);
    }

    internal (Map, List<(int startY, int startX)>, (int endY, int endX)) Parse2(string[] input)
    {
        var starts = new List<(int startY, int startX)>();

        var intTable = new int[input.Length][];

        var end = (-1, -1);

        for (int i = 0; i < input.Length; i++)
        {
            intTable[i] = new int[input[i].Length];

            for (int j = 0; j < input[i].Length; j++)
            {
                if (input[i][j] == 'S')
                {
                    starts.Add((i, j));
                    intTable[i][j] = 0;
                }
                else if (input[i][j] == 'E')
                {
                    end = (i, j);
                    intTable[i][j] = 'z' - 'a';
                }
                else if (input[i][j] == 'a')
                {
                    starts.Add((i, j));
                    intTable[i][j] = 0;
                }
                else
                {
                    intTable[i][j] = input[i][j] - 'a';
                }
            }
        }

        if (starts.Count == 0 || end == (-1, -1))
        {
            throw new ArgumentException("WAAAAAAAAAAAA");
        }

        return (new Map(intTable), starts, end);
    }
}