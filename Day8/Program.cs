using System.Data;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var parser = new Parser();

var table = parser.Parse(input);

var inspector = new Inspector(table);

var visibilityTable = inspector.GetVisibility();

var sum = 0;

foreach (var row in visibilityTable)
{
	foreach (var spot in row)
	{
		sum += Convert.ToInt32(spot);
	}
}

Console.WriteLine(sum);

var scoreTable = inspector.GetScenicScore();

var max = 0L;

foreach (var row in scoreTable)
{
    foreach (var spot in row)
    {
        max = (max > spot) ? max : spot;
    }
}

Console.WriteLine(max);