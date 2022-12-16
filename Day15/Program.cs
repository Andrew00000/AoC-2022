using System.Collections.Generic;
using System.Diagnostics;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var part1 = new Stopwatch();
part1.Start();
var parser = new Parser();

var rowNumber = 2000000;

(var sensors, var takenCoordinates) = parser.Parse(input, rowNumber);

var coveredCoordinates = new HashSet<int>();

foreach (var sensor in sensors)
{
    coveredCoordinates = sensor.UpdateCoveredCoordinatesInRow(coveredCoordinates, rowNumber);
}

var resultCoordinates = coveredCoordinates.Except(takenCoordinates);

part1.Stop();

Console.WriteLine(resultCoordinates.Count());

var part2 = new Stopwatch();
part2.Start();

var size = 4000000;
var rows = new List<(int min, int max)>[size + 1];

foreach (var sensor in sensors)
{
    rows = sensor.UpdateRows(rows);
}

var x = 0;
var y = 0;


var AmIDone = false;
for (int i = 0; i < rows.Length; i++)
{
    rows[i] = rows[i].OrderBy(x => x.min).ToList();
    var max = rows[i][0].max;

    for (int j = 0; j < rows[i].Count; j++)
    {
        var asd = rows[i];
        if (max < rows[i][j].min - 1) 
        {
            x = max + 1;
            y = i;
            AmIDone = true;
        }
        else if(max < rows[i][j].max)
        {
            max = rows[i][j].max;
        }

        if (AmIDone)
        {
            break;
        }
    }

    if (AmIDone)
    {
        break;
    }
}
 part2.Stop();

Console.WriteLine(x* 4000000L + y);

Console.WriteLine();
Console.WriteLine($"part1: {part1.Elapsed.TotalMilliseconds} ms");
Console.WriteLine($"part2: {part2.Elapsed.TotalMilliseconds} ms");