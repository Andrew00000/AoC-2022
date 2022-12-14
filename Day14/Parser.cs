internal class Parser
{
    internal (bool[][], (int y, int x)) Parse(string input)
    {
        (var yMax, var xMax, var offsetY, var offsetX) = GetSize(input);
        xMax -= offsetX;
        var cave = InitCave(yMax, xMax);

        var rockLines = input.Split(Environment.NewLine);

        foreach (var rockLine in rockLines)
        {
            var pairs = rockLine.Split(" -> ");

            (var currentY, var currentX) = (int.Parse(pairs[0].Split(',')[1]), int.Parse(pairs[0].Split(',')[0]) - offsetX);

            for (int i = 1; i < pairs.Length; i++)
            {
                (var nextY, var nextX) = (int.Parse(pairs[i].Split(',')[1]), int.Parse(pairs[i].Split(',')[0]) - offsetX);

                cave = DrawRocks(cave, (currentY, currentX), (nextY, nextX));

                currentY = nextY;
                currentX= nextX;
            }
            
        }

        return (cave, (0, 500 - offsetX));
    }

    internal (bool[][], (int y, int x)) ParseWithFloor(string input)
    {

        var startX = 500;
        (var yMax, var xMax, var yMin, var xMin) = GetSize(input);


        var cave = InitCaveWithFloor(yMax, 2 * xMax);
        
        var rockLines = input.Split(Environment.NewLine);

        foreach (var rockLine in rockLines)
        {
            var pairs = rockLine.Split(" -> ");

            (var currentY, var currentX) = (int.Parse(pairs[0].Split(',')[1]), int.Parse(pairs[0].Split(',')[0]));

            for (int i = 1; i < pairs.Length; i++)
            {
                (var nextY, var nextX) = (int.Parse(pairs[i].Split(',')[1]), int.Parse(pairs[i].Split(',')[0]));

                cave = DrawRocks(cave, (currentY, currentX), (nextY, nextX));

                currentY = nextY;
                currentX = nextX;
            }

        }

        return (cave, (0, startX));
    }


    private bool[][] DrawRocks(bool[][] cave, (int y, int x) current, (int y, int x) next)
    {
        if (current.y - next.y == 0)
        {
            (var smaller, var larger) = current.x < next.x ? (current.x, next.x) : (next.x, current.x);

            for (int j = smaller; j <= larger; j++)
            {
                cave[current.y][j] = false;
            }
        }
        else
        {
            (var smaller, var larger) = current.y < next.y ? (current.y, next.y) : (next.y, current.y);

            for (int i = smaller; i <= larger; i++)
            {
                cave[i][current.x] = false;
            }

        }

        return cave;
    }
    private bool[][] InitCaveWithFloor(int yMax, int xMax)
    {
        var cave = new bool[yMax+ 2][];

        for (int i = 0; i < yMax + 2; i++)
        {
            cave[i] = new bool[xMax];

            for (int j = 0; j < xMax; j++)
            {
                cave[i][j] = true;
                
                if (i == yMax + 1)
                {
                    cave[i][j] = false;
                }
            }
        }

        return cave;
    }

    private bool[][] InitCave(int yMax, int xMax)
    {
        var cave = new bool[yMax][];

        for (int i = 0; i < yMax; i++)
        {
            cave[i] = new bool[xMax];

            for (int j = 0; j < xMax; j++)
            {
                cave[i][j] = true;
            }
        }

        return cave;
    }

    private (int y, int x, int offsetY, int offsetX) GetSize(string input)
    {
        var yMax = 0;
        var xMax = 0;

        var yMin = 1000;
        var xMin = 1000;

        var pairs = input.Replace(Environment.NewLine, " -> ").Split(" -> ");

        foreach (var pair in pairs)
        {
            var y = int.Parse(pair.Split(',')[1]);
            var x = int.Parse(pair.Split(',')[0]);

            if (y > yMax)
            {
                yMax = y;
            }

            if ( yMin > y)
            {
                yMin = y;
            }

            if (x > xMax) 
            {
                xMax = x;
            }

            if (xMin > x)
            {
                xMin = x;
            }
        }

        return(yMax + 1, xMax + 1, yMin, xMin);
    }
}