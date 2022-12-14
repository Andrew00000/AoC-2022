internal class SandSlide
{
    public int Steps { get; private set; } = -1;
    private (int y, int x) start;

    internal void FillThatCave(bool[][] cave, SandFactory sandFactory, (int y, int x) start)
    {
        this.start.y = start.y;
        this.start.x = start.x;
        
        var IsCaveStable = false;
        
        while (!IsCaveStable)
        {
            Steps++;
            var sand = sandFactory.CreateSand(this.start, (cave.Length, cave[0].Length));

            sand.Fall(cave);

            if (sand.IsSettled)
            {
                cave[sand.position.y][sand.position.x] = false;
            }

            if (sand.FallingForever || !cave[this.start.y][this.start.x])
            {
                IsCaveStable = true;
            }

        }
            //PrintCave(cave);
    }

    private void PrintCave(bool[][] cave)
    {
        for (int i = 0; i < cave.Length; i++)
        {
            for (int j = 0; j < cave[i].Length; j++)
            {
                if (cave[i][j])
                {
                     Console.Write('.'); 
                }
                else
                {
                    Console.Write('#');
                }
            }
            Console.WriteLine();
        }
    }
}