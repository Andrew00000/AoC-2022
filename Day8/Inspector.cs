using System.ComponentModel.DataAnnotations;

public class Inspector
{
    private int[][] table;

    public Inspector(int[][] table)
    {
        this.table = table;
    }

    public bool[][] GetVisibility()
    {
        var visibilityTable = InitializeTable(table);

        for (int i = 1; i < table.Length - 1; i++)
        {
            for (int j = 1; j < table[i].Length - 1; j++)
            {
                visibilityTable[i][j] = IsVisibleFromAtLeastOneSide(i, j);
            }
        }        

        return visibilityTable;
    }

    public long[][] GetScenicScore()
    {
        var scoreTable = new long[table.Length][];

        for (int i = 0; i < table.Length; i++)
        {
            scoreTable[i] = new long[table[i].Length];
            for (int j = 0; j < table[i].Length; j++)
            {
                scoreTable[i][j] = GetScenicScore(i, j);
            }
        }

        return scoreTable;
    }

    private bool IsVisibleFromAtLeastOneSide(int i, int j)
    {
        var fromTop = true;
        var fromBottom = true;
        var fromLeft = true;
        var fromRight = true;

        var index = 1;

        var isVisible = fromTop || fromBottom || fromLeft || fromRight;

        while(isVisible && index < table.Length)
        {
            if (fromTop && InRange(i - index, j))
            {
                fromTop = IsVisible((-index, 0), (i, j));
            }

            if (fromBottom && InRange(i + index, j))
            {
                fromBottom = IsVisible((index, 0), (i, j));
            }

            if (fromLeft && InRange(i, j - index))
            {
                fromLeft = IsVisible((0, -index), (i, j));
            }

            if (fromRight && InRange(i, j + index))
            {
                fromRight = IsVisible((0, index), (i, j));
            }

            isVisible = fromTop || fromBottom || fromLeft || fromRight;
            index++;
        }

        return isVisible;
    }

    private long GetScenicScore(int i, int j)
    {
        var fromTop = true;
        var fromBottom = true;
        var fromLeft = true;
        var fromRight = true;

        var scoreTop = 0L;
        var scoreBottom = 0L;
        var scoreLeft = 0L;
        var scoreRight = 0L;

        var index = 1;

        var isVisible = fromTop || fromBottom || fromLeft || fromRight;

        while (isVisible && index < table.Length)
        {
            if (fromTop && InRange(i - index, j))
            {
                fromTop = IsVisible((-index, 0), (i, j));
                scoreTop++;
            }

            if (fromBottom && InRange(i + index, j))
            {
                fromBottom = IsVisible((index, 0), (i, j));
                scoreBottom++;
            }

            if (fromLeft && InRange(i, j - index))
            {
                fromLeft = IsVisible((0, -index), (i, j));
                scoreLeft++;
            }

            if (fromRight && InRange(i, j + index))
            {
                fromRight = IsVisible((0, index), (i, j));
                scoreRight++;
            }

            isVisible = fromTop || fromBottom || fromLeft || fromRight;
            index++;
        }


        return scoreTop * scoreBottom * scoreLeft * scoreRight;
    }

    private bool InRange(int i, int j)
    => i >= 0
      && j >= 0
      && table.Length > i
      && table[i].Length > j;

    private bool IsVisible((int i, int j) blocker, (int i, int j) tested)
        => table[tested.i][tested.j] > table[tested.i + blocker.i][tested.j + blocker.j];
    

    private bool[][] InitializeTable(int[][] table)
    {
        var visibilityTable = new bool[table.Length][];

        for (int i = 0; i < table.Length; i++)
        {
            visibilityTable[i] = new bool[table[i].Length];

            for (int j = 0; j < table[i].Length; j++)
            {
                if (i == 0 || i == table.Length - 1)
                {
                    visibilityTable[i][j] = true;
                }

                if (j == 0 || j == table[i].Length - 1)
                {
                    visibilityTable[i][j] = true;
                }
            }
        }

        return visibilityTable;
    }

}