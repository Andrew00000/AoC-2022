internal class Map
{
    private (int y, int x) goal;
    private (int y, int x) current;
    private (int y, int x) from;
    private (int height, int pathLength)[][] fieldTable;
    private readonly (int y, int x)[] directions = 
    {
        (-1,  0),
        ( 1,  0),
        ( 0, -1),
        ( 0,  1)
    };

    private Queue<(int, int, int, int)> nodesToCheck = new Queue<(int y, int x, int fromY, int fromX)> ();
    private HashSet<(int y, int x)> visitedNodes = new();
    public Map(int[][] intTable)
    {
        var height = intTable.Length;
        var width = intTable[0].Length;
        fieldTable = new (int height, int pathLength)[height][];

        for (int i = 0; i < height; i++)
        {
            fieldTable[i] = new (int height, int pathLenght)[width];
            for (int j = 0; j < width; j++)
            {
                fieldTable[i][j] = (intTable[i][j], height * width); 
            }
        }
    }

    internal int CalculateShortestRoute((int Y, int X) start, (int Y, int X) end)
    {
        visitedNodes.Clear();
        current = start;
        fieldTable[start.Y][start.X].pathLength = 0;
        goal = end;

        GetNodesToCheck(current);

        while(nodesToCheck.Count > 0)
        {
            (current.y, current.x, from.y, from.x) = nodesToCheck.Dequeue();
            
            AdjustPathLength(current, from);

            GetNodesToCheck(current);
        }

        return fieldTable[goal.y][goal.x].pathLength;
    }

    private void AdjustPathLength((int y, int x) tested, (int y, int x) previous)
    {
        if (fieldTable[tested.y][tested.x].pathLength > (fieldTable[previous.y][previous.x].pathLength + 1))
        {
            fieldTable[tested.y][tested.x].pathLength = fieldTable[previous.y][previous.x].pathLength + 1;
        }
    }

    private void GetNodesToCheck((int y, int x) current)
    {
        foreach (var direction in directions)
        {
            if (ShouldCheck((direction.y + current.y), (direction.x + current.x), current.y, current.x))
            {
                nodesToCheck.Enqueue(((direction.y + current.y), (direction.x + current.x), current.y, current.x));
            }
        }

        visitedNodes.Add(current);
    }

    private bool IsInBounds(int y, int x)
        => ( 0 <= y && y < fieldTable.Length)
        && ( 0 <= x && x < fieldTable[0].Length);

    private bool ShouldCheck(int y, int x, int fromY, int fromX)
        => IsInBounds(y, x) 
        && (y,x) != (fromY, fromX) 
        && !visitedNodes.Contains((y, x))
        && !nodesToCheck.Contains((y, x, fromY, fromX))
        && IsRightElevation(y, x, fromY, fromX);

    private bool IsRightElevation(int y, int x, int fromY, int fromX)
        => fieldTable[y][x].height - fieldTable[fromY][fromX].height <= 1;
}