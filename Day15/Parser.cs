internal class Parser
{
    internal (IEnumerable<Sensor> sensors, IEnumerable<int> taken) Parse(string[] input, int rowNumber)
    {
        var sensors = new List<Sensor>();
        var taken = new HashSet<int >();

        foreach (var line in input)
        {
            var sensorX = int.Parse(line.Split(' ')[2].TrimEnd(',').Split('=')[1]);
            var sensorY = int.Parse(line.Split(' ')[3].TrimEnd(':').Split('=')[1]);

            var beaconX = int.Parse(line.Split(' ')[8].TrimEnd(',').Split('=')[1]);
            var beaconY = int.Parse(line.Split(' ')[9].Split('=')[1]);

            var radius = Math.Abs(sensorY - beaconY) + Math.Abs(sensorX - beaconX);

            sensors.Add(new Sensor(sensorY, sensorX, radius));

            //taken.Add((sensorY, sensorX));
            if (beaconY == rowNumber)
            {
                taken.Add(beaconX);
            }
        }

        return (sensors, taken);
    }
}