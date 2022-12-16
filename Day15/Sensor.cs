internal class Sensor
{
    private int sensorY;
    private int sensorX;
    private int radius;
    private int size = 4000000;
    public (int min, int max) yRange { get; init; }
    public (int min, int max) xRange { get; init; }
    public Sensor(int sensorY, int sensorX, int radius)
    {
        this.sensorY = sensorY;
        this.sensorX = sensorX;
        this.radius = radius;
        yRange = ((sensorY - radius), (sensorY + radius));
        xRange = ((sensorX - radius), (sensorX + radius));
    }

    public bool IsInRange((int y, int x) tested)
        => (yRange.min <= tested.y && tested.y <= yRange.max)
        && (xRange.min <= tested.x && tested.x <= xRange.max);

    internal HashSet< int > UpdateCoveredCoordinatesInRow(HashSet<int> coveredCoordinates, int y)
    {
        if (Math.Abs(y - sensorY) > radius)
        {
            return coveredCoordinates;
        }

        var remainingRange = radius - Math.Abs(y - sensorY);
        var numbers = Enumerable.Range(sensorX - remainingRange, (sensorX + remainingRange) - (sensorX - remainingRange) + 1);

        
        coveredCoordinates.UnionWith( numbers );

        return coveredCoordinates;
    }

    internal List<(int, int)>[] UpdateRows(List<(int, int)>[] rows)
    {
        for (int i = 0; i <= radius; i++)
        {
            if (sensorY + i <= size)
            {
                if (rows[sensorY + i] is null)
                {
                    rows[sensorY + i] = new List<(int, int)>();
                }
                rows[sensorY + i].Add(GetXRange(radius - i));
            }


            if ((sensorY - i >= 0))
            {
                if (rows[sensorY - i] is null)
                {
                    rows[sensorY - i] = new List<(int, int)>();
                }
                if (i != 0)
                {
                    rows[sensorY - i].Add(GetXRange(radius - i));
                }
            }
        }

        return rows;
    }

    private (int min, int max) GetXRange(int radius)
        => (Math.Max((sensorX - radius), 0), Math.Min((sensorX + radius), size));
}