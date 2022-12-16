using System.Globalization;

internal class StressSignalFinder
{
    private (int y, int x) tableSize;
    private IEnumerable<Sensor> sensors;

    public StressSignalFinder((int, int) tableSize, IEnumerable<Sensor> sensors)
    {
        this.tableSize = tableSize;
        this.sensors = sensors;
    }

    internal (int y, int x) FindThatSpot()
    {
        var IsThatTheSpot = true;
        var y = 0;
        var x = 0;

        for (int i = 0; i < tableSize.y; i++)
        {
            for (int j = 0; j < tableSize.x; j++)
            {
                y = i;
                x = j;
                
                IsThatTheSpot = true;

                foreach (var sensor in sensors)
                {
                    if (IsThatTheSpot)
                    {
                        IsThatTheSpot &= !sensor.IsInRange((i, j));
                    }
                }

                if (IsThatTheSpot)
                {
                    break;
                }
            }

            if (IsThatTheSpot) 
            {
                break; 
            }
        }

        if (!IsThatTheSpot)
        {
            throw new ArgumentException("You missed a spot...");
        }

        return (y, x);
    }
}