internal class Sand
{
    public (int y, int x) position { get; private set; }
    private (int y, int x) cave;
    public bool IsSettled { get; private set; } = false;
    public bool FallingForever { get; private set; } = false;
    private bool DidMoveThisRound = false;

    private Dictionary<string, (int y, int x)> directions = new Dictionary<string, (int y, int x)>
    {
        {"Down", (1, 0) },
        {"DownLeft", (1, -1) },
        {"DownRight", (1, 1) },
    };

    public Sand((int y, int x) start, (int y, int x) cave)
    {
        position = start;
        this.cave = cave;
    }

    internal void Fall(bool[][] cave)
    {
        while(!IsSettled && !FallingForever)
        {
            DidMoveThisRound= false;

            Move(((position.y + 1), position.x), cave);

            if (DidMoveThisRound || FallingForever)
            {  
              //  PrintCave(cave);
                continue;
            }

            Move(((position.y + 1), position.x - 1), cave);

            if (DidMoveThisRound || FallingForever)
            {
            //    PrintCave(cave);

                continue;
            }

            Move(((position.y + 1), position.x + 1), cave);

            if (DidMoveThisRound || FallingForever)
            {
          //      PrintCave(cave);

                continue;
            }

            IsSettled = true;

        }
        
        //PrintCave(cave);
    }

    private void Move((int y, int x) position, bool[][] cave) 
    {
        if (IsWithinBounds((position.y, position.x)))
        {
            if (cave[position.y][position.x])
            {
                this.position = (position.y, position.x);
                DidMoveThisRound = true;
            }
        }
        else
        {
            FallingForever = true;
        }
    }

    private void PrintCave(bool[][] cave)
    {
        for (int i = 0; i < cave.Length; i++)
        {
            for (int j = 0; j < cave[i].Length; j++)
            {
                if (cave[i][j])
                {
                    Console.Write(' ');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }

    private bool IsWithinBounds((int y, int x) targetPosition)
    => (targetPosition.y < cave.y)
       && (0 <= targetPosition.x && targetPosition.x < cave.x);

}